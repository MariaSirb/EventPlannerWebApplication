using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EventPlannerWebApplication.Data;
using EventPlannerWebApplication.Models.Services;

namespace EventPlannerWebApplication.Pages.Foods
{
    public class CreateModel : PageModel
    {
        private readonly EventPlannerWebApplication.Data.EventPlannerWebApplicationContext _context;

        public CreateModel(EventPlannerWebApplication.Data.EventPlannerWebApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Food Food { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            byte[] bytes1 = null;
            if (Food.MancareImageFile != null)
            {
                using (Stream fs1 = Food.MancareImageFile.OpenReadStream())
                {
                    using (BinaryReader br1 = new BinaryReader(fs1))
                    {
                        bytes1 = br1.ReadBytes((Int32)fs1.Length);

                    }

                }
                Food.MancareImage = Convert.ToBase64String(bytes1, 0, bytes1.Length);
            }

            _context.Food.Add(Food);
            await _context.SaveChangesAsync();

             return RedirectToPage("./Index");

            //if (!ModelState.IsValid)
            //  {
            //      return Page();
            //  }

            //  _context.Food.Add(Food);
            //  await _context.SaveChangesAsync();

            //  return RedirectToPage("./Index");
        }
    }
}
