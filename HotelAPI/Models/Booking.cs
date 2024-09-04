namespace HotelAPI.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int HotelBranchId { get; set; }
        public HotelBranch HotelBranch { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
