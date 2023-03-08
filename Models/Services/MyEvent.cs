using System.ComponentModel.DataAnnotations;

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

        // Facem relatia cu DJ(Muzica)

        public int? MusicID { get; set; }
        public Music? Music { get; set; }

        //Facem relatia cu Fotograful

        public int? PhotographID { get; set; }
        public Photograph? Photograph { get;set; }

        //Clientul

        public int? ClientID { get; set; }
        public Client? Client { get; set; }


        


    }


}
