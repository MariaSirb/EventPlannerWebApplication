using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EventPlannerWebApplication.Data;
using EventPlannerWebApplication.Models;

namespace EventPlannerWebApplication.Pages.CreatingEvents
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

        ViewData["ClientID"] = new SelectList(_context.Client, "ID", "ID");
        ViewData["MyEventID"] = new SelectList(_context.MyEvent, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public CreatingEvent CreatingEvent { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CreatingEvent.Add(CreatingEvent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
