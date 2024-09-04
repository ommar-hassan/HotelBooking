using HotelClient.Interfaces;
using HotelClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelClient.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;
        private readonly IHotelBranchService _hotelBranchService;

        public BookingController(IBookingService bookingService, IRoomService roomService, IHotelBranchService hotelBranchService)
        {
            _bookingService = bookingService;
            _roomService = roomService;
            _hotelBranchService = hotelBranchService;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int customerId, string? customerName)
        {
            ViewBag.CustomerId = customerId;
            if (customerName != null)
                ViewBag.CustomerName = customerName;

            var branches = await _hotelBranchService.GetAllBranchesAsync() ?? new List<HotelBranchViewModel>();
            var rooms = await _roomService.GetAvailableRoomsAsync() ?? new List<RoomViewModel>();

            ViewBag.Branches = new SelectList(branches, "Id", "Name");
            ViewBag.Rooms = new SelectList(rooms, "RoomId", "RoomType");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var success = await _bookingService.CreateBookingAsync(model);
                if (success)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Failed to create booking.");
            }

            var branches = await _hotelBranchService.GetAllBranchesAsync() ?? new List<HotelBranchViewModel>();
            var rooms = await _roomService.GetAvailableRoomsAsync() ?? new List<RoomViewModel>();

            ViewBag.Branches = new SelectList(branches, "Id", "Name");
            ViewBag.Rooms = new SelectList(rooms, "RoomId", "RoomType");

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return View(bookings);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }
    }
}
