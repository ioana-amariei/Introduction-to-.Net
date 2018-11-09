using System;
using Vanguard;

namespace DataLayer
{
    public class PointOfInterest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string City { get; set; }

        public PointOfInterest()
        {
            // EF
        }

        public PointOfInterest(string name, string description, double latitude, double longitude, string city)
        {
            Guard.ArgumentNotNullOrEmpty(name, nameof(name));
            Guard.ArgumentNotNullOrEmpty(description, nameof(description));

            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Latitude = latitude;
            Longitude = longitude;
            City = city;
        }
    }
}