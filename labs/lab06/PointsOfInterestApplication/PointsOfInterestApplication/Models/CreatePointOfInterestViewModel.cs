using System.ComponentModel.DataAnnotations;

namespace PointsOfInterestApplication.Models
{
    public class CreatePointOfInterestModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Description { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string City { get; set; }
    }
}
