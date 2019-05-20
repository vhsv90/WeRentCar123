using System.Collections.Generic;
using System.Linq;
using WeRentCar123.Models.Repository;

namespace WeRentCar123.Models.Manager
{
    public class ClientsManager : IDataRepository<Clients>
    {

        public readonly DB.AppContext _appContext;

        public ClientsManager(DB.AppContext appContext)
        {
            _appContext = appContext;
        }

        public void Add(Clients entity)
        {
            _appContext.Clients.Add(entity);
            _appContext.SaveChanges();
        }

        public void Delete(Clients entity)
        {
            _appContext.Clients.Remove(entity);
            _appContext.SaveChanges();
        }

        public Clients Get(object id)
        {
            return _appContext
                .Clients
                .FirstOrDefault(x => x.Id.Equals((int)id))
                ;
        }

        public IEnumerable<Clients> GetAll()
        {
            return _appContext.Clients.ToList();
        }
    }
}
