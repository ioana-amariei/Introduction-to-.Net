using System;
using DataLayer;

namespace BusinessLayer
{
    public interface IRepository
    {
        void CreateCity(City city);
        void RemoveCity(Guid id);
        void AddPointOfInterest(Guid cityId, PointOfInterest pointOfInterest);
        void RemovePointOfInterest(Guid id, Guid cityId);
    }
}
