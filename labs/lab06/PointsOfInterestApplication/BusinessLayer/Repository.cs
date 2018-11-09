using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BusinessLayer
{
    public class Repository : IRepository
    {
        private readonly PointOfInterestContext _context;

        public Repository(PointOfInterestContext context)
        {
            _context = context;
        }

        public async  Task Create(PointOfInterest pointOfInterest)
        {
            _context.Add(pointOfInterest);
            await _context.SaveChangesAsync();
        }

        public async Task Update(PointOfInterest pointOfInterest)
        {
            _context.Update(pointOfInterest);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var pointOfInterest = _context.PointOfInterests.Find(id);
            _context.PointOfInterests.Remove(pointOfInterest);
            await _context.SaveChangesAsync();
        }

        public Task<List<PointOfInterest>> GetAll()
        {
            return _context.PointOfInterests.ToListAsync();
        }

        public Task<PointOfInterest> FirstOrDefault(Guid? id)
        {
            return _context.PointOfInterests.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<PointOfInterest> FindAsync(Guid? id)
        {
            return _context.PointOfInterests.FindAsync(id);
        }

        public bool Exists(Guid id)
        {
            return _context.PointOfInterests.Any(p => p.Id == id);
        }
    }
}