using System;
using System.Linq;

namespace WeRentCar123.Models.DB
{
    public static class SeedData
    {

        public static void Initialize(AppContext appContext)
        {
            appContext.Database.EnsureCreated();

            if (!appContext.Vehicles.Any())
            {
                appContext.Vehicles.AddRange(
                    new Vehicles {
                        Id = Guid.NewGuid(),
                        Brand = "Nissan",
                        Color = "Gray",
                        Model = "Sentra",
                        Year = 2002,
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
                        Year = 2004,
                        Client = null,
                        DailyPrice = 0,
                        RentedDays = 0,
                        Notes = "",
                        ImageSrc = "https://saints-auto.com/wp-content/uploads/2017/06/car-placeholder-2-700.jpg"
                    }
                );
            }

            if (!appContext.Clients.Any())
            {
                appContext.Clients.AddRange(
                    new Clients
                    {
                        Id = Guid.NewGuid(),
                        Name = "Victor",
                        LastName = "Sanchez",
                        PhoneNumber = "+506 8484-2807"
                    }
                );
            }

        }

    }
}
