using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PetClinic.Models
{
    public class Person : IdentityUser 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
    }
}
