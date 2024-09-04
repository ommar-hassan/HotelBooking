using HotelClient.Interfaces;
using HotelClient.Models;
using Newtonsoft.Json;

namespace HotelClient.Services
{
    public class RoomService : IRoomService
    {
        private readonly Uri baseAddress = new("https://localhost:7028/api/room");
        private readonly HttpClient _client;

        public RoomService()
        {
            _client = new HttpClient
            {
                BaseAddress = baseAddress
            };
        }

        public async Task<List<RoomViewModel?>?> GetAvailableRoomsAsync()
        {
            var response = await _client.GetAsync($"{_client.BaseAddress}/available");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<RoomViewModel?>?>(data);
            }
            return null;
        }
    }
}
