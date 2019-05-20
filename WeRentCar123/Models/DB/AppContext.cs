using Microsoft.EntityFrameworkCore;
using System;

namespace WeRentCar123.Models.DB
{
    public class AppContext : DbContext
    {

        public AppContext(DbContextOptions options)
            :base(options)
        {}

        public DbSet<Clients> Clients { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicles>().HasData(
                new Vehicles
                {
                    Id = Guid.NewGuid(),
                    Brand = "Nissan",
                    Color = "Gray",
                    Model = "Sentra",
                    Year = 2018,
                    Client = null,
                    DailyPrice = 0,
                    RentedDays = 0,
                    Notes = "",
                    ImageSrc = "https://saints-auto.com/wp-content/uploads/2017/06/car-placeholder-2-700.jpg"
                },
                new Vehicles
                {
                    Id = Guid.NewGuid(),
                    Brand = "Toyota",
                    Color = "Blue",
                    Model = "Corolla",
                    Year = 2019,
                    Client = null,
                    DailyPrice = 0,
                    RentedDays = 0,
                    Notes = "",
                    ImageSrc = "https://saints-auto.com/wp-content/uploads/2017/06/car-placeholder-2-700.jpg"
                },
                new Vehicles
                {
                    Id = Guid.NewGuid(),
                    Brand = "Ford",
                    Color = "Yellow",
                    Model = "Raptor",
                    Year = 2016,
                    Client = null,
                    DailyPrice = 0,
                    RentedDays = 0,
                    Notes = "",
                    ImageSrc = "https://saints-auto.com/wp-content/uploads/2017/06/car-placeholder-2-700.jpg"
                }, 
                new Vehicles
                {
                    Id = Guid.NewGuid(),
                    Brand = "Dodge",
                    Color = "Black",
                    Model = "Caravan",
                    Year = 2016,
                    Client = null,
                    DailyPrice = 0,
                    RentedDays = 0,
                    Notes = "",
                    ImageSrc = "https://saints-auto.com/wp-content/uploads/2017/06/car-placeholder-2-700.jpg"
                },
                new Vehicles
                {
                    Id = Guid.NewGuid(),
                    Brand = "Honda",
                    Color = "Black",
                    Model = "Civiv",
                    Year = 2017,
                    Client = null,
                    DailyPrice = 0,
                    RentedDays = 0,
                    Notes = "",
                    ImageSrc = "https://saints-auto.com/wp-content/uploads/2017/06/car-placeholder-2-700.jpg"
                }
            );

            modelBuilder.Entity<Clients>().HasData(
                new Clients {
                    Id = Guid.NewGuid(),
                    Name = "Victor",
                    LastName = "Sanchez",
                    PhoneNumber = "+506 8484-2807"
                },
                new Clients
                {
                    Id = Guid.NewGuid(),
                    Name = "Wei",
                    LastName = "Chung",
                    PhoneNumber = "+506 7889-2807"
                },
                new Clients
                {
                    Id = Guid.NewGuid(),
                    Name = "John",
                    LastName = "White",
                    PhoneNumber = "+506 9090-2807"
                },
                new Clients
                {
                    Id = Guid.NewGuid(),
                    Name = "Hannah",
                    LastName = "Barbera",
                    PhoneNumber = "+506 4455-2807"
                }
            );

        }

    }
}
