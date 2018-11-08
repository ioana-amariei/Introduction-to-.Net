using System;
using Vanguard;

namespace DataLayer
{
    public class PointOfInterest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CityId { get; set; }

        public PointOfInterest()
        {
            // EF
        }

        public PointOfInterest(string name, string description)
        {
            Guard.ArgumentNotNullOrEmpty(name, nameof(name));
            Guard.ArgumentNotNullOrEmpty(description, nameof(description));

            Id = Guid.NewGuid();
            Name = name;
            Description = description;
        }

        public void AttachCity(Guid id)
        {
            CityId = id;
        }
    }
}