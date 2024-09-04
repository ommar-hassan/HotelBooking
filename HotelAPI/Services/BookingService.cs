using HotelAPI.Data;
using HotelAPI.Dtos;
using HotelAPI.Interfaces;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICustomerService _customerService;
        private readonly IRoomService _roomService;

        public BookingService(
            ApplicationDbContext context,
            ICustomerService customerService, 
            IRoomService roomService)
        {
            _context = context;
            _customerService = customerService;
            _roomService = roomService;
        }

        public async Task<BookingDto> CreateAsync(CreateBookingDto entity)
        {
            var customer = await _customerService.GetByIdAsync(entity.CustomerId)
                ?? throw new Exception("Customer not found.");
            var r = entity.Rooms[0].RoomId;
            var roomIds = entity.Rooms.Select(r => r.RoomId).ToList();
            var roomsToBook = await _context.Rooms
                .Where(r => roomIds.Contains(r.Id) && !r.IsBooked)
                .ToListAsync();

            if (roomsToBook.Count != entity.Rooms.Count)
            {
                throw new Exception("One or more rooms are already booked or do not exist.");
            }

            double totalPrice = CalculateTotalPrice(roomsToBook, entity.CheckIn, entity.CheckOut, customer.HasBookedBefore);

            var booking = new Booking
            {
                CustomerId = entity.CustomerId,
                HotelBranchId = entity.HotelBranchId,
                CheckIn = entity.CheckIn,
                CheckOut = entity.CheckOut,
                TotalPrice = totalPrice,
                Rooms = roomsToBook
            };

            
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            await _customerService.Booked(customer.CustomerId);

            await _roomService.UpdateRoomDetailsAsync(entity.Rooms, booking.Id);
            var hotelBranch = await _context.HotelBranches
                .AsNoTracking()
                .FirstOrDefaultAsync(hb => hb.Id == entity.HotelBranchId);

            return new BookingDto
            {
                Id = booking.Id,
                CustomerName = customer.Name,
                HotelBranch = hotelBranch?.Name ?? "Unknown Branch",
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                TotalPrice = booking.TotalPrice,
                Rooms = roomsToBook.Select(r => new RoomDto
                {
                    IsBooked = r.IsBooked,
                    RoomId = r.Id,
                    RoomType = r.RoomType.ToString(),
                    Price = r.Price,
                    NumberOfAdults = r.NumberOfAdults,
                    NumberOfChildren = r.NumberOfChildren
                }).ToList()
            };
        }

        private double CalculateTotalPrice(IEnumerable<Room> rooms, DateTime checkIn, DateTime checkOut, bool hasBookedBefore)
        {
            int totalNights = (checkOut.Date - checkIn.Date).Days;

            double totalPrice = rooms.Sum(room => room.Price * totalNights);

            if (hasBookedBefore)
            {
                totalPrice *= 0.95;
            }

            return totalPrice;
        }

        public async Task<IEnumerable<BookingDto?>> GetAllAsync()
        {
            return await _context.Bookings
                .AsNoTracking()
                .Select(b => new BookingDto
                {
                    Id = b.Id,
                    CustomerName = b.Customer.Name,
                    HotelBranch = b.HotelBranch.Name,
                    CheckIn = b.CheckIn,
                    CheckOut = b.CheckOut,
                    TotalPrice = b.TotalPrice,
                    Rooms = b.Rooms.Select(r => new RoomDto
                    {
                        RoomId = r.Id,
                        RoomType = r.RoomType.ToString(),
                        Price = r.Price,
                        NumberOfAdults = r.NumberOfAdults,
                        NumberOfChildren = r.NumberOfChildren
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<BookingDto?> GetByIdAsync(int id)
        {
            var booking = await _context.Bookings
                .AsNoTracking()
                .Include(b => b.Rooms)
                .Include(b => b.Customer)
                .Include(b => b.HotelBranch)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (booking == null)
            {
                return null;
            }

            return new BookingDto
            {
                Id = booking.Id,
                CustomerName = booking.Customer.Name,
                HotelBranch = booking.HotelBranch.Name,
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                TotalPrice = booking.TotalPrice,
                Rooms = booking.Rooms.Select(r => new RoomDto
                {
                    RoomId = r.Id,
                    RoomType = r.RoomType.ToString(),
                    Price = r.Price,
                    NumberOfAdults = r.NumberOfAdults,
                    NumberOfChildren = r.NumberOfChildren
                }).ToList()
            };
        }
    }
}
