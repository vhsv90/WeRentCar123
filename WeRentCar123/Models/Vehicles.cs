using System;

namespace WeRentCar123.Models
{
    public class Vehicles
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string Notes { get; set; }
        public Clients Client { get; set; }
        public double DailyPrice { get; set; }
        public int RentedDays { get; set; }
        public string ImageSrc { get; set; }
    }
}
