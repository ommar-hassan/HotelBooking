using HotelClient.Models;

namespace HotelClient.Interfaces
{
    public interface IHotelBranchService
    {
        Task<List<HotelBranchViewModel?>?> GetAllBranchesAsync();
    }
}
