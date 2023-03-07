using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EventPlannerWebApplication.Data;
using EventPlannerWebApplication.Models.Services;
using System.Security.Policy;
using EventPlannerWebApplication.Models;

namespace EventPlannerWebApplication.Pages.MyEvents
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
            ViewData["TipEvenimentID"] = new SelectList(_context.Set<TipEveniment>(), "ID", "DenumireEveniment");
            ViewData["LocatieID"] = new SelectList(_context.Set<Locatie>(), "ID", "DenumireLocatie");
            ViewData["MusicID"] = new SelectList(_context.Set<Music>(), "ID", "NumeDj");
            ViewData["PhotographID"] = new SelectList(_context.Set<Photograph>(), "ID", "DenumirePhotograph");


            return Page();
        }

        [BindProperty]
        public MyEvent MyEvent { get; set; } 
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MyEvent.Add(MyEvent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
