using HotelAPI.Interfaces;
using HotelAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelBranchController : ControllerBase
    {
        private readonly IHotelBranchService _hotelBranchService;

        public HotelBranchController(IHotelBranchService hotelBranchService)
        {
            _hotelBranchService = hotelBranchService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelBranch>>> GetAllBranches()
        {
            var branches = await _hotelBranchService.GetAllBranchesAsync();
            return Ok(branches);
        }
    }
}