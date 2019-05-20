using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeRentCar123.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(object id);
        void Add(TEntity entity);
        //void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
        //IEnumerable<TEntity> Search(string searchTerm);        
    }
}
