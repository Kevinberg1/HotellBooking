using HotellBooking.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellBooking.Controller
{
    public class Build
    {
        public ApplicationDbContext BuildApp()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"Appsettings.json", true, true);
            var config = builder.Build();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);

            using (var dbContext = new ApplicationDbContext(options.Options))
            {
                var dataInitiaizer = new DataInitializer();
                dataInitiaizer.MigrateAndSeed(dbContext);
            }
            var dbContextReturned = new ApplicationDbContext(options.Options);
            return dbContextReturned;
        }
    }
}
