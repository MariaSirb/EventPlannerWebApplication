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
    public class IndexModel : PageModel
    {
        private readonly EventPlannerWebApplication.Data.EventPlannerWebApplicationContext _context;

        public IndexModel(EventPlannerWebApplication.Data.EventPlannerWebApplicationContext context)
        {
            _context = context;
        }

        public IList<CreatingEvent> CreatingEvent { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CreatingEvent != null)
            {
                CreatingEvent = await _context.CreatingEvent
                .Include(c => c.Client)
                .Include(c => c.MyEvent).ToListAsync();
            }
        }
    }
}
