using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Drawing2D;

namespace EventPlannerWebApplication.Models.Services
{
    public class Drink
    {
        public int ID { get; set; }
     

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Numele Locatiei trebuie sa fie cu litera mare (ex. Briliant)!")]
        [Display(Name = "Tipul bauturii")]
        public string DenumireBautura { get; set; }
       
        [Column(TypeName = "decimal(8,2)")]
        [Range(0.01, 500)]
        [Display(Name = "Pret (lei)/persoana")]
        public decimal PretBautura { get; set; }
        public string BauturaImage { get; set; }
        [NotMapped]
        public IFormFile BauturaImageFile { get; set; }
    }
}
