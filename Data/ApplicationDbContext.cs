using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetClinic.Models;

namespace PetClinic.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Veterinary> Veterinaries { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
