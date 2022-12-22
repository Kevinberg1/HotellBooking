using HotellBooking.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellBooking.Controller.Booking
{
    public class ReadBooking : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }

        public ReadBooking(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Run()
        {

            Console.Clear();
            Console.WriteLine(" Bookings information");
            Console.WriteLine("\n Bokings Id\tStart Datum\t\tSlut Datum\t\tRum-nummer");

            // If no bookings in system
            if (dbContext.Bookings == null)
            {
                Console.WriteLine("Det finns inga bokingar. ");
            }
            else
            {
                // Lets join tables including, 
                var bookingInclAllData = dbContext.Bookings
                    .Include(b => b.HotellRoom);

                // display active bookings
                foreach (var booking in bookingInclAllData.Include(b=>b.Guests).OrderBy(b => b.Id))
                {
                    Console.WriteLine(
                        $" {booking.Id}\t{booking.Guests.Name}\t{booking.DateTimeStart.ToShortDateString()}\t{booking.DateTimeEnd.ToShortDateString()}\t{booking.HotellRoom.Id}");


                }
            }

            Console.WriteLine("\n tyck på någpt");
            Console.ReadLine();
            Console.Clear();

        }
    }
}
