using HotelClient.Models;

namespace HotelClient.Interfaces
{
    public interface IRoomService
    {
        public Task<List<RoomViewModel?>?> GetAvailableRoomsAsync();
    }
}
