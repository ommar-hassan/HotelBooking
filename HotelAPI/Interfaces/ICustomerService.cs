using HotelAPI.Dtos;
using HotelAPI.Models;

namespace HotelAPI.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDto?> GetByIdAsync(int id);
        Task<CustomerDto> CreateAsync(CreateCustomerDto entity);
        Task Booked(int id);
    }
}
