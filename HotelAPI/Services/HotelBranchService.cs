using HotelAPI.Data;
using HotelAPI.Interfaces;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Services
{
    public class HotelBranchService : IHotelBranchService
    {
        private readonly ApplicationDbContext _context;

        public HotelBranchService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<HotelBranch>> GetAllBranchesAsync()
        {
            var branches = await _context.HotelBranches.ToListAsync()
                ?? throw new Exception("No branches found!");
            return branches;
        }
    }
}
