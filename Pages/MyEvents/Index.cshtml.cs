using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventPlannerWebApplication.Data;
using EventPlannerWebApplication.Models.Services;

namespace EventPlannerWebApplication.Pages.MyEvents
{
    public class IndexModel : PageModel
    {
        private readonly EventPlannerWebApplication.Data.EventPlannerWebApplicationContext _context;

        public IndexModel(EventPlannerWebApplication.Data.EventPlannerWebApplicationContext context)
        {
            _context = context;
        }

        public IList<MyEvent> MyEvent { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MyEvent != null)
            {
                MyEvent = await _context.MyEvent
                    .Include(b=>b.TipEveniment)
                    .Include(b=>b.Locatie)
                    .Include(b=>b.Music)
                    .Include(b=>b.Photograph)
                    .ToListAsync();
            }
        }
    }
}
