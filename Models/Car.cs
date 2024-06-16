using System.Formats.Asn1;

namespace Carss.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string CarNumber { get; set; }
        public decimal CostPerDay { get; set; }
        public decimal EngineCapacity { get; set; }
        public string Fuel { get; set; }
        public int TransmissionId { get; set; }
        public int ClassId { get; set; }

        public Transmission Transmission { get; set; }
        public CarClass CarClass { get; set; }
        public ICollection<CarRentNow> CarRentNows { get; set; }
    }
}
