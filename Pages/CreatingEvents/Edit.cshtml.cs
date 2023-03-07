using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventPlannerWebApplication.Data;
using EventPlannerWebApplication.Models;

namespace EventPlannerWebApplication.Pages.CreatingEvents
{
    public class EditModel : PageModel
    {
        private readonly EventPlannerWebApplication.Data.EventPlannerWebApplicationContext _context;

        public EditModel(EventPlannerWebApplication.Data.EventPlannerWebApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CreatingEvent CreatingEvent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CreatingEvent == null)
            {
                return NotFound();
            }

            var creatingevent =  await _context.CreatingEvent.FirstOrDefaultAsync(m => m.ID == id);
            if (creatingevent == null)
            {
                return NotFound();
            }
            CreatingEvent = creatingevent;
           ViewData["ClientID"] = new SelectList(_context.Client, "ID", "ID");
           ViewData["MyEventID"] = new SelectList(_context.MyEvent, "ID", "ID");
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

            _context.Attach(CreatingEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreatingEventExists(CreatingEvent.ID))
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

        private bool CreatingEventExists(int id)
        {
          return _context.CreatingEvent.Any(e => e.ID == id);
        }
    }
}
