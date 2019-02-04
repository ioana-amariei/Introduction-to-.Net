using System.ComponentModel.DataAnnotations;

namespace Booking.Business
{
    public class CreatingCustomerModel
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
