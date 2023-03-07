using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlannerWebApplication.Models.Services
{
    public class Photograph
    {
        public int ID { get; set; }
        public string DenumirePhotograph { get; set; }

        public decimal PretPhotograph { get; set; }
        public string PhotographImage { get; set; }
        [NotMapped]
        public IFormFile PhotographImageFile { get; set; }

        public ICollection<MyEvent> ? MyEvents { get; set; }
    }
}
