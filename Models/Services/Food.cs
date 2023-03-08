using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlannerWebApplication.Models.Services
{
    public class Food
    {
        public int ID { get; set; }
        public string DenumireMancare { get; set; }

        public decimal PretMancare { get; set; }
        public string MancareImage { get; set; }
        [NotMapped]
        public IFormFile MancareImageFile { get; set; }

        
    }
}
