using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlannerWebApplication.Models.Services
{
    public class Locatie
    {
        public int ID { get; set; }

        public string LocationImage { get; set; }

        [NotMapped]
        public IFormFile LocationImageFile { get; set; }

        public string DenumireLocatie { get; set; }
        public string Adresa { get; set; }
        public int CapacitateMaxima { get; set; }
        public decimal PretLocatie { get; set; }

        public ICollection<MyEvent> MyEvents { get; set; }  

    }
}
