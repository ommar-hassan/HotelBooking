using HotelClient.Models;

namespace HotelClient.Interfaces
{
    public interface IBookingService
    {
        public Task<List<BookingViewModel?>?> GetAllBookingsAsync();

        public Task<BookingViewModel?> GetBookingByIdAsync(int id);

        public Task<bool> CreateBookingAsync(CreateBookingViewModel model);
    }
}
