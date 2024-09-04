using HotelClient.Interfaces;
using HotelClient.Models;
using Newtonsoft.Json;
using System.Text;

namespace HotelClient.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _client;
        private readonly Uri baseAddress = new("https://localhost:7028/api/Customer");

        public CustomerService()
        {
            _client = new HttpClient
            {
                BaseAddress = baseAddress
            };
        }

        public async Task<int?> CreateCustomerAsync(CreateCustomerViewModel model)
        {
            try
            {
                var json = JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync($"{_client.BaseAddress}", content);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var customer = JsonConvert.DeserializeObject<CustomerViewModel>(data);
                    return customer?.CustomerId;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating customer: {ex.Message}");
            }
        }
    }
}
