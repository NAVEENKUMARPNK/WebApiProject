using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class LocationDbContext: DbContext
    {
        public LocationDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Location> Location { get; set; }
    }
}
