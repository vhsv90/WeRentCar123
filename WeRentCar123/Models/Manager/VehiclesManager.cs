using System;
using System.Collections.Generic;
using System.Linq;
using WeRentCar123.Models.Repository;

namespace WeRentCar123.Models.Manager
{
    public class VehiclesManager : IDataRepository<Vehicles>
    {

        public readonly DB.AppContext _appContext;

        public VehiclesManager(DB.AppContext appContext)
        {
            _appContext = appContext;
        }

        public void Add(Vehicles entity)
        {
            _appContext.Vehicles.Add(entity);
            _appContext.SaveChanges();
        }

        public void Delete(Vehicles entity)
        {
            _appContext.Vehicles.Remove(entity);
            _appContext.SaveChanges();
        }

        public Vehicles Get(object id)
        {
            var result = _appContext
                .Vehicles
                .FirstOrDefault(x => x.Id.Equals((Guid)id))
                ;

            if(result!= null)
                return result;

            return null;
        }

        public IEnumerable<Vehicles> GetAll()
        {
            return _appContext.Vehicles.Where(x => x.Client.Equals(null)).ToList();
        }

        public void RentVehicle(Guid vehicleId, Guid clientId)
        {
            var vehicle = _appContext.Vehicles.Where(x => x.Id.Equals(vehicleId)).SingleOrDefault();
            vehicle.Client = _appContext.Clients.Where(x => x.Id.Equals(clientId)).SingleOrDefault();
            _appContext.SaveChanges();
        }
    }
}
