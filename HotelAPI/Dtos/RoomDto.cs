namespace HotelAPI.Dtos
{
    public class RoomDto
    {
        public int RoomId { get; set; }
        public string RoomType { get; set; }
        public double Price { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public bool IsBooked { get; set; }
    }
}
