using HotellBooking.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellBooking.Controller
{
    public class Read : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }

        public Read(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Run()
        {
           
                Console.Clear();
                Console.WriteLine(" Bookings information");
                Console.WriteLine("\n Id\tStart\t\tEnd\t\tCar");
                
                // If no bookings in system
                if (dbContext.Bookings == null)
                {
                    Console.WriteLine("Det finns inga bokingar. ");
                }
                else
                {
                    // Lets join tables including, 
                    var bookingInclAllData = dbContext.Bookings
                        .Include(b => b.room);

                    // display active bookings
                    foreach (var booking in bookingInclAllData.OrderBy(b => b.Id))
                    {
                        Console.WriteLine(
                            $" {booking.Id}\t{booking.DateTimeStart.ToShortDateString()}\t{booking.DateTimeEnd.ToShortDateString()}\t{booking.room.Id}");

                     
                    }
                }

                Console.WriteLine("\n Press any key to continue");
                Console.ReadLine();
                Console.Clear();
            
        }
    }
}
