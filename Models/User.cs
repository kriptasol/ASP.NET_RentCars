namespace Carss.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }

        public ICollection<CarRentNow> CarRentNows { get; set; }
    }
}
