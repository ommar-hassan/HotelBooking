using HotelAPI.Dtos;
using HotelAPI.Models;

namespace HotelAPI.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto?>> GetAllAsync();
        Task<BookingDto?> GetByIdAsync(int id);
        Task<BookingDto> CreateAsync(CreateBookingDto entity);
    }
}
