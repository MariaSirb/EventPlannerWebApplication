using EventPlannerWebApplication.Models.Services;

namespace EventPlannerWebApplication.Models
{
    public class TipEveniment
    {
        public int ID { get; set; }
        public string DenumireEveniment { get; set; }

        public ICollection<MyEvent>? MyEvents { get; set; }

    }
}
