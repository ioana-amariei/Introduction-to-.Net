using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public interface IRepository
    {
        Task Create(PointOfInterest pointOfInterest);
        Task Update(PointOfInterest pointOfInterest);
        Task Delete(Guid id);
        Task<List<PointOfInterest>> GetAll();
        Task<PointOfInterest> FirstOrDefault(Guid? id);
        Task<PointOfInterest> FindAsync(Guid? id);
        bool Exists(Guid id);
    }
}
