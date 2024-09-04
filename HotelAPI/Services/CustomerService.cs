using HotelAPI.Data;
using HotelAPI.Dtos;
using HotelAPI.Interfaces;
using HotelAPI.Models;

namespace HotelAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerDto?> GetByIdAsync(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer == null)
            {
                return null;
            }

            return new CustomerDto
            {
                CustomerId = customer.Id,
                Name = customer.Name,
                NationalId = customer.NationalId,
                PhoneNumber = customer.PhoneNumber,
                HasBookedBefore = customer.HasBookedBefore
            };
        }

        public async Task<CustomerDto> CreateAsync(CreateCustomerDto createCustomerDto)
        {
            var customer = new Customer
            {
                Name = createCustomerDto.Name,
                NationalId = createCustomerDto.NationalId,
                PhoneNumber = createCustomerDto.PhoneNumber,
                HasBookedBefore = false
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return new CustomerDto
            {
                CustomerId = customer.Id,
                Name = customer.Name,
                NationalId = customer.NationalId,
                PhoneNumber = customer.PhoneNumber,
                HasBookedBefore = customer.HasBookedBefore
            };
        }

        public async Task Booked(int id)
        {
            var customer = await _context.Customers.FindAsync(id) 
                ?? throw new Exception("Invalid Customer Id");
            customer.HasBookedBefore = true;
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
