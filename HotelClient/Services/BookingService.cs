using HotelClient.Interfaces;
using HotelClient.Models;
using Newtonsoft.Json;
using System.Text;

namespace HotelClient.Services
{
    public class BookingService : IBookingService
    {
        private readonly Uri baseAddress = new("https://localhost:7028/api/booking");
        private readonly HttpClient _client;

        public BookingService()
        {
            _client = new HttpClient
            {
                BaseAddress = baseAddress
            };
        }

        public async Task<List<BookingViewModel?>?> GetAllBookingsAsync()
        {
            var response = await _client.GetAsync($"{_client.BaseAddress}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<BookingViewModel?>?>(data);
            }
            return null;
        }

        public async Task<BookingViewModel?> GetBookingByIdAsync(int id)
        {
            var response = await _client.GetAsync($"{_client.BaseAddress}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BookingViewModel>(data);
            }
            return null;
        }

        public async Task<bool> CreateBookingAsync(CreateBookingViewModel model)
        {
            try
            {
                var json = JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync($"{_client.BaseAddress}", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while booking: {ex.Message}");
            }
        }
    }
}
