using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventPlannerWebApplication.Data;
using EventPlannerWebApplication.Models;

namespace EventPlannerWebApplication.Pages.CreatingEvents
{
    public class DeleteModel : PageModel
    {
        private readonly EventPlannerWebApplication.Data.EventPlannerWebApplicationContext _context;

        public DeleteModel(EventPlannerWebApplication.Data.EventPlannerWebApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CreatingEvent CreatingEvent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CreatingEvent == null)
            {
                return NotFound();
            }

            var creatingevent = await _context.CreatingEvent.FirstOrDefaultAsync(m => m.ID == id);

            if (creatingevent == null)
            {
                return NotFound();
            }
            else 
            {
                CreatingEvent = creatingevent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CreatingEvent == null)
            {
                return NotFound();
            }
            var creatingevent = await _context.CreatingEvent.FindAsync(id);

            if (creatingevent != null)
            {
                CreatingEvent = creatingevent;
                _context.CreatingEvent.Remove(CreatingEvent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
