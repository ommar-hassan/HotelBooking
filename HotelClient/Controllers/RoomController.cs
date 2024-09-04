using HotelClient.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelClient.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public async Task<IActionResult> Available()
        {
            var rooms = await _roomService.GetAvailableRoomsAsync();
            return View(rooms);
        }
    }
}
