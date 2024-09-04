using HotelAPI.Dtos;
using HotelAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDto>> GetRoomById(int id)
        {
            var room = await _roomService.GetByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetAvailableRooms()
        {
            var rooms = await _roomService.GetAvailableRoomsAsync();
            return Ok(rooms);
        }

        [HttpPost("{id}/book")]
        public async Task<ActionResult> MarkRoomAsBooked(int id, [FromBody] int bookingId)
        {
            var success = await _roomService.MarkRoomAsBookedAsync(id, bookingId);
            if (!success)
            {
                return BadRequest("Room could not be booked or is already booked.");
            }
            return Ok();
        }
    }
}