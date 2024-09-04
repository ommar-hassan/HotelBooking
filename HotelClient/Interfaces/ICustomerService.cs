using HotelClient.Models;

namespace HotelClient.Interfaces
{
    public interface ICustomerService
    {
        public Task<int?> CreateCustomerAsync(CreateCustomerViewModel model);
    }
}
