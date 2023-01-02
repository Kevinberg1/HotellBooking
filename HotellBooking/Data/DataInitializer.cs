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
            if (!dbContext.HotellRooms.Any(c => c.Type == "Dubbelrum"))
            {
                dbContext.HotellRooms.Add(new HotellRoom
                {
                    Type = "Dubbelrum",
                    beds = 2,
                    Size = 52
                });
            }
            if (!dbContext.HotellRooms.Any(c => c.Type == "Dubbelrum"))
            {
                dbContext.HotellRooms.Add(new HotellRoom
                {
                    Type = "Dubbelrum",
                    beds = 2,
                    Size = 43
                });
            }
            if (!dbContext.HotellRooms.Any(c => c.Type == "Enkelrum"))
            {
                dbContext.HotellRooms.Add(new HotellRoom
                {
                    Type = "Enkelrum",
                    beds = 1,
                    Size = 32
                });
            }
            if (!dbContext.HotellRooms.Any(c => c.Type == "Enkelrum"))
            {
                dbContext.HotellRooms.Add(new HotellRoom
                {
                    Type = "Enkelrum",
                    beds = 1,
                    Size = 28
                });
            }

        }

        private void SeedGuest(ApplicationDbContext dbContext)
        {
            if (!dbContext.Guests.Any(c => c.Name == "Adam"))
            {
                dbContext.Guests.Add(new Guests
                {
                    Name = "Adam",
                    LastName = "Borg"
                });
            }
            if (!dbContext.Guests.Any(c => c.Name == "Lilly"))
            {
                dbContext.Guests.Add(new Guests
                {
                    Name = "Lilly",
                    LastName = "Gustavsson"
                });
            }
            if (!dbContext.Guests.Any(c => c.Name == "Pelle"))
            {
                dbContext.Guests.Add(new Guests
                {
                    Name = "Pelle",
                    LastName = "Johansson"
                });
            }
            if (!dbContext.Guests.Any(c => c.Name == "Eva"))
            {
                dbContext.Guests.Add(new Guests
                {
                    Name = "Eva",
                    LastName = "Eriksson"
                });
            }
        }
    }
}
