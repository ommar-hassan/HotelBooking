using HotelAPI.Models;

namespace HotelAPI.Interfaces
{
    public interface IHotelBranchService
    {
        Task<List<HotelBranch>> GetAllBranchesAsync();
    }
}
