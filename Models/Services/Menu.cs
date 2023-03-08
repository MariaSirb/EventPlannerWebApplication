using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlannerWebApplication.Models.Services
{
    public class Menu
    {
        public int ID { get; set; }
        public string DenumireItem { get; set; }

        public decimal PretItem { get; set; }
        public string ItemImage { get; set; }
        [NotMapped]
        public IFormFile ItemImageFile { get; set; }

    }
}
