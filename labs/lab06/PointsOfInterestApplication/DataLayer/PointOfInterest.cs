using System;
using Vanguard;

namespace DataLayer
{
    public class PointOfInterest
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public string City { get; private set; }

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