﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EventPlannerWebApplication.Data;
using EventPlannerWebApplication.Models.Services;

namespace EventPlannerWebApplication.Pages.Locatii
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
            return Page();
        }

        [BindProperty]
        public Locatie Locatie { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD

        public async Task<IActionResult> OnPostAsync()
        {
            byte[] bytes = null;
            if (Locatie.LocationImageFile != null)
            {
                using (Stream fs = Locatie.LocationImageFile.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        bytes = br.ReadBytes((Int32)fs.Length);

                    }

                }
                Locatie.LocationImage = Convert.ToBase64String(bytes, 0, bytes.Length);
            }
            _context.Locatie.Add(Locatie);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
           
            
            //if (!ModelState.IsValid)
            //  {
            //      return Page();
            //  }

            //  _context.Locatie.Add(Locatie);
            //  await _context.SaveChangesAsync();

            //  return RedirectToPage("./Index");
        }
    }
}
