using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellBooking.Data
{

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Guests> Guests { get; set; }
        public DbSet<HotellRoom> HotellRooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public ApplicationDbContext()
        {
            
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=HotellData;Trusted_Connection=True;TrustServerCertificate=true;");
            }
        }

    }
}



