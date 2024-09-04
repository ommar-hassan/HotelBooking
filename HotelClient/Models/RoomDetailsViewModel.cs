using System.ComponentModel.DataAnnotations;

namespace HotelClient.Models
{
    public class RoomDetailsViewModel
    {
        public int RoomId { get; set; }
        [Display(Name = "Number of adults")]
        public int NumberOfAdults { get; set; }
        [Display(Name = "Number of children")]
        public int NumberOfChildren { get; set; }
    }
}
