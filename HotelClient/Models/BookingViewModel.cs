using System.ComponentModel.DataAnnotations;

namespace HotelClient.Models
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Display(Name = "Hotel Branch")]
        public string HotelBranch { get; set; }
        [Display(Name = "Check-In")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CheckIn { get; set; }
        [Display(Name = "Check-Out")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CheckOut { get; set; }
        [Display(Name = "Total Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double TotalPrice { get; set; }
        public List<RoomViewModel> Rooms { get; set; } = new List<RoomViewModel>();
    }
}
