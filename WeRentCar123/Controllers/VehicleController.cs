using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WeRentCar123.Models;
using WeRentCar123.Models.Manager;
using WeRentCar123.Models.Repository;

namespace WeRentCar123.Controllers
{
    [Route("api/[controller]")]
    public class VehicleController : Controller
    {
        private readonly VehiclesManager _vehiclesManager;

        public VehicleController(IDataRepository<Vehicles> vehiclesManager)
        {
            _vehiclesManager = vehiclesManager as VehiclesManager;
        }

        [HttpGet]
        public IEnumerable<Vehicles> GetAll()
        {
            return _vehiclesManager.GetAll();
        }

        [HttpGet("{id}")]
        public Vehicles Get(Guid id)
        {
            return _vehiclesManager.Get(id);
        }

        [HttpDelete]
        public void Delete(Vehicles vehicles)
        {
            _vehiclesManager.Delete(vehicles);
        }

        [HttpPost]
        public void Add(Vehicles vehicles)
        {
            _vehiclesManager.Add(vehicles);
        }

        [HttpPut]
        public void RentVehicle(Guid vehicleId, Guid clientId)
        {
            _vehiclesManager.RentVehicle(vehicleId, clientId);
        }

    }
}
