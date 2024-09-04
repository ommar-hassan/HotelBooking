namespace HotelAPI.Models
{
    public class Room
    {
        public int Id { get; set; }
        public RoomType RoomType { get; set; }
        public double Price { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public bool IsBooked { get; set; }
        public int? BookingId { get; set; }
        public Booking Booking { get; set; }
    }
}
