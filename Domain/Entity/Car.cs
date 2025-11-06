namespace Domain.Entity
{
    public class Car : BaseEntity
    {
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int YearOfManufacture { get; set; }
        public string Km { get; set; }
        public int DailyPrice { get; set; }
        public CarStatus Status { get; set; }
    }

    public enum CarStatus
    {
        Available = 1,
        Reserved = 2,
        InUse = 3,
        UnderMantenance = 4
    }
}
