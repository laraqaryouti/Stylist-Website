using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Data
{
    public class FinalProjectContext : DbContext
    {
        public FinalProjectContext (DbContextOptions<FinalProjectContext> options)
            : base(options)
        {
        }

        public DbSet<FinalProject.Models.Consultation> Consultation { get; set; } = default!;

        public DbSet<FinalProject.Models.UserAccount>? UserAccount { get; set; }

        public DbSet<FinalProject.Models.StylistAccount>? StylistAccount { get; set; }
    }
}
