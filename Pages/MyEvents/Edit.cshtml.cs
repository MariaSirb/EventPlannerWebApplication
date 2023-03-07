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
using EventPlannerWebApplication.Models;

namespace EventPlannerWebApplication.Pages.MyEvents
{
    public class EditModel : PageModel
    {
        private readonly EventPlannerWebApplication.Data.EventPlannerWebApplicationContext _context;

        public EditModel(EventPlannerWebApplication.Data.EventPlannerWebApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MyEvent MyEvent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MyEvent == null)
            {
                return NotFound();
            }

            var myevent =  await _context.MyEvent.FirstOrDefaultAsync(m => m.ID == id);
            if (myevent == null)
            {
                return NotFound();
            }
            MyEvent = myevent;

            ViewData["TipEvenimentID"] = new SelectList(_context.Set<TipEveniment>(), "ID", "DenumireEveniment");
            ViewData["LocatieID"] = new SelectList(_context.Set<Locatie>(), "ID", "DenumireLocatie");
            ViewData["MusicID"] = new SelectList(_context.Set<Music>(), "ID", "NumeDj");
            ViewData["PhotographID"] = new SelectList(_context.Set<Photograph>(), "ID", "DenumirePhotograph");

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

            _context.Attach(MyEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyEventExists(MyEvent.ID))
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

        private bool MyEventExists(int id)
        {
          return _context.MyEvent.Any(e => e.ID == id);
        }
    }
}
