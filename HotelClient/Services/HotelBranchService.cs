using HotelClient.Interfaces;
using HotelClient.Models;
using Newtonsoft.Json;

namespace HotelClient.Services
{
    public class HotelBranchService : IHotelBranchService
    {
        private readonly HttpClient _client;
        private readonly Uri baseAddress = new("https://localhost:7028/api/HotelBranch");

        public HotelBranchService()
        {
            _client = new HttpClient
            {
                BaseAddress = baseAddress
            };
        }

        public async Task<List<HotelBranchViewModel?>?> GetAllBranchesAsync()
        {
            var response = await _client.GetAsync($"{_client.BaseAddress}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<HotelBranchViewModel?>>(data);
            }
            return null;
        }
    }
}
