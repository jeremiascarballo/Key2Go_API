
namespace Contract.Car.Request
{
    public class CarRequest
    {
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int YearOfManufacture { get; set; }
        public int Km { get; set; }
        public decimal DailyPriceUsd { get; set; }
        public int Status { get; set; }
    }
}
