using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WeRentCar123.Models;
using WeRentCar123.Models.Repository;

namespace WeRentCar123.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly IDataRepository<Clients> _clientsManager;

        public ClientController(IDataRepository<Clients> clientsManager)
        {
            _clientsManager = clientsManager;
        }

        [HttpGet]
        public IEnumerable<Clients> GetAll()
        {
            return _clientsManager.GetAll();
        }

        [HttpGet("{id}")]
        public Clients Get(Guid id)
        {
            return _clientsManager.Get((Guid)id);
        }

        [HttpDelete]
        public void Delete(Clients clients)
        {
            _clientsManager.Delete(clients);
        }

        [HttpPost]
        public void Add(Clients clients)
        {
            _clientsManager.Add(clients);
        }

    }
}
