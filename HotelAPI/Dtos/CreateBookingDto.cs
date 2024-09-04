namespace HotelAPI.Dtos
{
    public class CreateBookingDto
    {
        public int CustomerId { get; set; }
        public int HotelBranchId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public List<RoomDetailsDto> Rooms { get; set; } = new List<RoomDetailsDto>();
    }
}
