namespace Carss.Models
{
    public class CarClass
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
