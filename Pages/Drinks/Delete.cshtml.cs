using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventPlannerWebApplication.Data;
using EventPlannerWebApplication.Models.Services;

namespace EventPlannerWebApplication.Pages.Drinks
{
    public class DeleteModel : PageModel
    {
        private readonly EventPlannerWebApplication.Data.EventPlannerWebApplicationContext _context;

        public DeleteModel(EventPlannerWebApplication.Data.EventPlannerWebApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Drink Drink { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Drink == null)
            {
                return NotFound();
            }

            var drink = await _context.Drink.FirstOrDefaultAsync(m => m.ID == id);

            if (drink == null)
            {
                return NotFound();
            }
            else 
            {
                Drink = drink;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Drink == null)
            {
                return NotFound();
            }
            var drink = await _context.Drink.FindAsync(id);

            if (drink != null)
            {
                Drink = drink;
                _context.Drink.Remove(Drink);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
