namespace Carss.Models
{
    public class CarRentNow
    {
        public int RentId { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int RentDay { get; set; }
        public decimal CostAllTime { get; set; }

        public User User { get; set; }
        public Car Car { get; set; }
    }
}
