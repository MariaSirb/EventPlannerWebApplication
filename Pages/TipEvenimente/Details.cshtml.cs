using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventPlannerWebApplication.Data;
using EventPlannerWebApplication.Models;

namespace EventPlannerWebApplication.Pages.TipEvenimente
{
    public class DetailsModel : PageModel
    {
        private readonly EventPlannerWebApplication.Data.EventPlannerWebApplicationContext _context;

        public DetailsModel(EventPlannerWebApplication.Data.EventPlannerWebApplicationContext context)
        {
            _context = context;
        }

      public TipEveniment TipEveniment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TipEveniment == null)
            {
                return NotFound();
            }

            var tipeveniment = await _context.TipEveniment.FirstOrDefaultAsync(m => m.ID == id);
            if (tipeveniment == null)
            {
                return NotFound();
            }
            else 
            {
                TipEveniment = tipeveniment;
            }
            return Page();
        }
    }
}
