using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HotelClient.Models
{
    public class CreateBookingViewModel
    {
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        [Display(Name = "Branch")]
        public int HotelBranchId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public List<RoomDetailsViewModel> Rooms { get; set; } = new List<RoomDetailsViewModel>();
    }
}
