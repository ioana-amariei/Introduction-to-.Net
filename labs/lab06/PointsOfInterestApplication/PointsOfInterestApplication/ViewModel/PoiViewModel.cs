using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PointsOfInterestApplication.ViewModel
{
    public class PoiViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public Guid? Id { get; set; }

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
