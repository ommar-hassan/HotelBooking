﻿namespace HotelAPI.Dtos
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string NationalId { get; set; }
        public string PhoneNumber { get; set; }
        public bool HasBookedBefore { get; set; }
    }
}
