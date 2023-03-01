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
    public class DetailsModel : PageModel
    {
        private readonly EventPlannerWebApplication.Data.EventPlannerWebApplicationContext _context;

        public DetailsModel(EventPlannerWebApplication.Data.EventPlannerWebApplicationContext context)
        {
            _context = context;
        }

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
    }
}
