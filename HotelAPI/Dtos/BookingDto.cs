namespace HotelAPI.Dtos
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string HotelBranch { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public double TotalPrice { get; set; }
        public List<RoomDto> Rooms { get; set; } = new List<RoomDto>();
    }
}
