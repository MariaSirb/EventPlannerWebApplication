using EventPlannerWebApplication.Models.Services;

namespace EventPlannerWebApplication.Models
{
    public class CreatingEvent
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? MyEventID { get; set; }

        public MyEvent? MyEvent { get; set; }
        
    }
}
