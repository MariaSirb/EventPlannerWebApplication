using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlannerWebApplication.Models.Services
{
    public class Drink
    {
        public int ID { get; set; }
        public string DenumireBautura { get; set; }

        public decimal PretBautura { get; set; }
        public string BauturaImage { get; set; }
        [NotMapped]
        public IFormFile BauturaImageFile { get; set; }
    }
}
