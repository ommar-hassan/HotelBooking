using HotelClient.Interfaces;
using HotelClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelClient.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customerId = await _customerService.CreateCustomerAsync(model);
                if (customerId.HasValue)
                {
                    return RedirectToAction("Create", "Booking", new { customerId = customerId.Value,customerName = model.Name.ToString() });
                }
                ModelState.AddModelError("", "Failed to create customer.");
            }
            return View(model);
        }
    }
}
