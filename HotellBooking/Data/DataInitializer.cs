using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellBooking.Data
{
    public class DataInitializer
    {
        public void MigrateAndSeed(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();
            SeedRoom(dbContext);
            SeedGuest(dbContext);
            dbContext.SaveChanges();
        }
        private void SeedRoom(ApplicationDbContext dbContext)
        {
            if (!dbContext.HotellRooms.Any(c => c.Id == "rum nummer: 1"))
            {
                dbContext.HotellRooms.Add(new HotellRoom
                {
                    Id = "rum nummer: 1",
                    Type = "Här kan 1 person bo",
                });
            }

            if (!dbContext.HotellRooms.Any(c => c.Id == "rum nummer: 2"))
            {
                dbContext.HotellRooms.Add(new HotellRoom
                {
                    Id = "rum nummer: 2",
                    Type = "här kan 2 personer bo",
                });
            }
        }

        private void SeedGuest(ApplicationDbContext dbContext)
        {
            ///ska personer
        }
    }
}
