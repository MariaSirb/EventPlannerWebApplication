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
    public class IndexModel : PageModel
    {
        private readonly EventPlannerWebApplication.Data.EventPlannerWebApplicationContext _context;

        public IndexModel(EventPlannerWebApplication.Data.EventPlannerWebApplicationContext context)
        {
            _context = context;
        }

        public IList<Photograph> Photograph { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Photograph != null)
            {
                Photograph = await _context.Photograph.ToListAsync();
            }
        }
    }
}
