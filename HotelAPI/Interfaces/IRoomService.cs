using HotelAPI.Dtos;
using HotelAPI.Models;

namespace HotelAPI.Interfaces
{
    public interface IRoomService
    {
        Task<RoomDto?> GetByIdAsync(int roomId);
        Task<IEnumerable<RoomDto>> GetAvailableRoomsAsync();
        public Task UpdateRoomDetailsAsync(List<RoomDetailsDto> rooms, int bookingId);
        Task<bool> MarkRoomAsBookedAsync(int roomId, int bookingId);
    }
}
