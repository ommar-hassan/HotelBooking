using System.ComponentModel.DataAnnotations;

namespace HotelClient.Models
{
    public class RoomViewModel
    {
        public int RoomId { get; set; }
        [Display(Name = "Room Type")]
        public string RoomType { get; set; }
        public double Price { get; set; }
        [Display(Name = "Number of adults")]
        public int NumberOfAdults { get; set; }
        [Display(Name = "Number of children")]
        public int NumberOfChildren { get; set; }
        public bool IsBooked { get; set; }
    }
}
