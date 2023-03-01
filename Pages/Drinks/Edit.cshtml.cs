using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventPlannerWebApplication.Data;
using EventPlannerWebApplication.Models.Services;

namespace EventPlannerWebApplication.Pages.Drinks
{
    public class EditModel : PageModel
    {
        private readonly EventPlannerWebApplication.Data.EventPlannerWebApplicationContext _context;

        public EditModel(EventPlannerWebApplication.Data.EventPlannerWebApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Drink Drink { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Drink == null)
            {
                return NotFound();
            }

            var drink =  await _context.Drink.FirstOrDefaultAsync(m => m.ID == id);
            if (drink == null)
            {
                return NotFound();
            }
            Drink = drink;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Drink).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinkExists(Drink.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DrinkExists(int id)
        {
          return _context.Drink.Any(e => e.ID == id);
        }
    }
}
