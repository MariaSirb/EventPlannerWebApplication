using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventPlannerWebApplication.Data;
using EventPlannerWebApplication.Models.Services;

namespace EventPlannerWebApplication.Pages.Photographs
{
    public class DetailsModel : PageModel
    {
        private readonly EventPlannerWebApplication.Data.EventPlannerWebApplicationContext _context;

        public DetailsModel(EventPlannerWebApplication.Data.EventPlannerWebApplicationContext context)
        {
            _context = context;
        }

      public Photograph Photograph { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Photograph == null)
            {
                return NotFound();
            }

            var photograph = await _context.Photograph.FirstOrDefaultAsync(m => m.ID == id);
            if (photograph == null)
            {
                return NotFound();
            }
            else 
            {
                Photograph = photograph;
            }
            return Page();
        }
    }
}
