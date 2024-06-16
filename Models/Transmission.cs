namespace Carss.Models
{
    public class Transmission
    {
        public int TransmId { get; set; }
        public string Transm { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
