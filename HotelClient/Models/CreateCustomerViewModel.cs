using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace HotelClient.Models
{
    public class CreateCustomerViewModel
    {
        [Display(Name = "Full Name")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 alphabet characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain only alphabets")]
        [Required(ErrorMessage = "Customer name is required")]
        public string Name { get; set; }

        [Display(Name = "National ID")]
        [StringLength(50, ErrorMessage = "National ID should not exceed 50 characters")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "National ID must contain only numbers")]
        public string NationalId { get; set; }

        [Display(Name = "Phone Number")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone number must be 11 number")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Phone number must contain only numbers")]
        public string PhoneNumber { get; set; }
    }
}
