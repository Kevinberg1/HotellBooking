using HotellBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            foreach (var booking in dbContext.Bookings)
            {
                Console.WriteLine($"Id: {booking.Id}");
                Console.WriteLine($"Namn: {booking.Guests}");
                Console.WriteLine($"Namn: {booking.DateTimeStart} {booking.DateTimeEnd}");
                Console.WriteLine("====================");
            }

            Console.WriteLine("Välj Id på den bookning som du vill radera");
            var personIdToDelete = Convert.ToInt32(Console.ReadLine());
            var personToDelete = dbContext.Bookings.First(p => p.Id == personIdToDelete);
            dbContext.Bookings.Remove(personToDelete);
            dbContext.SaveChanges();
            //Console.WriteLine("vill du tillbaka skriv ja om inte skriv nej");
            //string g4 = Console.ReadLine();
            //if (g4.ToLower() == "ja")
            //{
            //    Console.Clear();

            //}
            //else
            //{
            //    Console.Clear();
            //    return;

            //}
        }

    }
}
