#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LiveTrafficProject.Models;

namespace LiveTrafficProject.Data
{
    public class LiveTrafficProjectContext : DbContext
    {
        public LiveTrafficProjectContext (DbContextOptions<LiveTrafficProjectContext> options)
            : base(options)
        {
        }

        public DbSet<LiveTrafficProject.Models.Incident> Incident { get; set; }

        public DbSet<LiveTrafficProject.Models.Properties> Properties { get; set; }
    }
}
