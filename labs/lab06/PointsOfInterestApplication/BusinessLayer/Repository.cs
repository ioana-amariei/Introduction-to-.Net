using System;
using System.Linq;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class Repository : IRepository
    {
        private readonly CityContext _context;

        public Repository(CityContext context)
        {
            _context = context;
        }

        public async void CreateCity(City city)
        {
            _context.Add(city);
            await _context.SaveChangesAsync();
        }

        public async void RemoveCity(Guid id)
        {
            var city = _context.Cities.Find(id);
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
        }

        public void AddPointOfInterest(Guid cityId, PointOfInterest pointOfInterest)
        {
            var city = _context.Cities
                .FirstOrDefault(c => c.Id == cityId);

            if (city != null)
            {
                city.AttachPointOfInterest(pointOfInterest);
                _context.SaveChanges();
            }
        }

        public void RemovePointOfInterest(Guid cityId, Guid pointOfInterestId)
        {
            var city = _context.Cities
                .Include(c => c.PointOfInterests)
                .FirstOrDefault(c => c.Id == cityId);

            if (city != null)
            {
                MarkAsDeleted(city.DetachPointOfInterest(pointOfInterestId));
                _context.SaveChanges();
            }
        }

        private void MarkAsDeleted(PointOfInterest pointOfInterest)
        {
            _context.Entry(pointOfInterest).State = EntityState.Deleted;
        }
    }
}