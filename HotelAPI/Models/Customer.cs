namespace HotelAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalId { get; set; }
        public bool HasBookedBefore { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
