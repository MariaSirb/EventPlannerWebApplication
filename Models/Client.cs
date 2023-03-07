﻿using EventPlannerWebApplication.Models.Services;
using System.ComponentModel.DataAnnotations;

namespace EventPlannerWebApplication.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public string? Adress { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }

        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;             
            }
            
        }
        public ICollection<MyEvent>? MyEvents { get; set; }
    }
}
