using HotelAPI.Data;
using HotelAPI.Dtos;
using HotelAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HotelAPI.Services
{
    public class RoomService : IRoomService
    {
        private readonly ApplicationDbContext _context;

        public RoomService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoomDto>> GetAvailableRoomsAsync()
        {
            var rooms = await _context.Rooms
                .Where(r => !r.IsBooked)
                .OrderBy(r => r.RoomType)
                .ToListAsync();
            
            return rooms.Select(room => new RoomDto
            {
                RoomId = room.Id,
                RoomType = room.RoomType.ToString(),
                Price = room.Price,
                NumberOfAdults = room.NumberOfAdults,
                NumberOfChildren = room.NumberOfChildren,
                IsBooked = room.IsBooked
            }).ToList();
        }

        public async Task<bool> MarkRoomAsBookedAsync(int roomId, int bookingId)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            if (room == null || room.IsBooked)
            {
                return false;
            }

            room.IsBooked = true;
            room.BookingId = bookingId;
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<RoomDto?> GetByIdAsync(int roomId)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            if (room == null)
            {
                return null;
            }

            return new RoomDto
            {
                RoomId = room.Id,
                RoomType = room.RoomType.ToString(),
                Price = room.Price,
                NumberOfAdults = room.NumberOfAdults,
                NumberOfChildren = room.NumberOfChildren,
                IsBooked = room.IsBooked
            };
        }

        public async Task UpdateRoomDetailsAsync(List<RoomDetailsDto> rooms, int bookingId)
        {
            var roomIds = rooms.Select(r => r.RoomId).ToList();
            var roomsToUpdate = await _context.Rooms
                .Where(r => roomIds.Contains(r.Id) && !r.IsBooked)
                .ToListAsync();

            if (roomsToUpdate.Count != rooms.Count)
            {
                throw new Exception("One or more rooms are already booked or do not exist.");
            }

            var roomsDictionary = roomsToUpdate.ToDictionary(r => r.Id);

            foreach (var roomDto in rooms)
            {
                if (roomsDictionary.TryGetValue(roomDto.RoomId, out var room))
                {
                    room.IsBooked = true;
                    room.NumberOfAdults = roomDto.NumberOfAdults;
                    room.NumberOfChildren = roomDto.NumberOfChildren;
                    room.BookingId = bookingId;
                }
                else
                {
                    throw new Exception($"Room with ID {roomDto.RoomId} was not found.");
                }
            }

            _context.Rooms.UpdateRange(roomsToUpdate);
            await _context.SaveChangesAsync();
        }

    }
}
