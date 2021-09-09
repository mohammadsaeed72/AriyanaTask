using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Unit> Units { get; set; }
        public DbSet<UnitType> Unittypes { get; set; }
        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
