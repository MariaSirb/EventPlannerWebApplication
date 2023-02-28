using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlannerWebApplication.Models.Services
{
    public class Music
    {
        public int ID { get; set; }
        public string NumeDj { get; set; }

        public decimal PretDj { get; set; }

        public string DjImage { get; set; }

        [NotMapped]
        public IFormFile DjImageFile { get; set; }
    }
}
