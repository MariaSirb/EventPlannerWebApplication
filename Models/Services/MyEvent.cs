namespace EventPlannerWebApplication.Models.Services
{
    public class MyEvent
    {
        public int ID { get; set; }

        public string Mentiune { get; set; }

        // Facem relatia cu Tip eveniment

        public int? TipEvenimentID { get; set; }
        public TipEveniment? TipEveniment { get; set; }

        // Facem relatia cu Locatia

        public int? LocatieID { get; set; }
        public Locatie? Locatie { get; set; }
    }
}
