using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PointsOfInterestApplication.Models
{
    public class UpdatePointOfInterestViewModel
    {
        public Guid id;

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
