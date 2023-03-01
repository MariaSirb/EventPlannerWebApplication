using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EventPlannerWebApplication.Models.Services;

namespace EventPlannerWebApplication.Data
{
    public class EventPlannerWebApplicationContext : DbContext
    {
        public EventPlannerWebApplicationContext (DbContextOptions<EventPlannerWebApplicationContext> options) : base(options)
        {
        }

        public DbSet<EventPlannerWebApplication.Models.Services.Locatie> Locatie { get; set; } = default!;

        public DbSet<EventPlannerWebApplication.Models.Services.Food> Food { get; set; } = default!;

        public DbSet<EventPlannerWebApplication.Models.Services.Music> Music { get; set; }

        public DbSet<EventPlannerWebApplication.Models.Services.Drink> Drink { get; set; }

        public DbSet<EventPlannerWebApplication.Models.Services.Photograph> Photograph { get; set; }
    }
}
