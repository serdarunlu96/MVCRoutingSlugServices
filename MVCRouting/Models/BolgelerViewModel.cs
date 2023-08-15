using MVCRouting.Data;
namespace MVCRouting.Models
{
    public class BolgelerViewModel
    {
        public Bolge Bolge { get; set; } = null!;

        public List<Sehir> Sehirler { get; set; } = new();
    }
}
