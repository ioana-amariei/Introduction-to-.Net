using System;
using System.Collections.Generic;
using System.Linq;
using Vanguard;

namespace DataLayer
{
    public class City
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
        
        public string Description { get; set; }

        public bool IsCapital { get; set; }

        public ICollection<PointOfInterest> PointOfInterests { get; set; }

        public City()
        {
            // EF
        }

        public City(string name, double latitude, double longitude, string description, bool isCapital)
        {
            Id = Guid.NewGuid();
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
            Description = description;
            IsCapital = isCapital;
            PointOfInterests = new List<PointOfInterest>();
        }

        public void AttachPointOfInterest(PointOfInterest pointOfInterest)
        {
            Guard.ArgumentNotNull(pointOfInterest, nameof(pointOfInterest));
            PointOfInterests.Add(pointOfInterest);
        }

        public PointOfInterest DetachPointOfInterest(Guid id)
        {
            var pointOfInterest = PointOfInterests.FirstOrDefault(poi => poi.Id == id);
            PointOfInterests.Remove(pointOfInterest);
            return pointOfInterest;
        }
    }
}
