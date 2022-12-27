using HotellBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotellBooking.Controller.Booking
{
    public class Deletebooking : ICrud
    {
        
            public ApplicationDbContext dbContext { get; set; }

            public Deletebooking(ApplicationDbContext context)
            {
                dbContext = context;
            }

            public void Run()
            {
            Console.Clear();


            Console.WriteLine("Ta bort en booking, vilken ?");
            foreach (var booking in dbContext.Bookings.Include(b => b.Guests))
            {
                Console.WriteLine($"Boknings ID:: {booking.Id}");
                Console.WriteLine($"Gäst namn: {booking.Guests.Name}");
                Console.WriteLine($"Start/Slut Datum: {booking.DateTimeStart} {booking.DateTimeEnd}");
                Console.WriteLine("====================");
            }

            Console.WriteLine("Välj Id på den bookning som du vill radera");
            var personIdToDelete = Convert.ToInt32(Console.ReadLine());
            var personToDelete = dbContext.Bookings.First(p => p.Id == personIdToDelete);
            dbContext.Bookings.Remove(personToDelete);
            dbContext.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Bokningen är nu raderad från systemet");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\n Tryck ENTER");
            Console.ReadLine();
            Console.Clear();
        }

    }
}
