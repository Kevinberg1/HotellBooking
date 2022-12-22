using HotellBooking.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellBooking.Controller.Booking
{
    public class UpdateBooking : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }

        public UpdateBooking(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Run()
        {
            Console.Clear();


            Console.WriteLine("ändra befintlig bokning");
            foreach (var booking in dbContext.Bookings)
            {
                Console.WriteLine($"Boknings Id: {booking.Id}");
                Console.WriteLine($"Gäst: {booking.Guests}");
                Console.WriteLine($"start/slut Datum: {booking.DateTimeStart} {booking.DateTimeEnd}");
                Console.WriteLine("====================");
            }

            Console.WriteLine("Välj Id på den bokning som du vill uppdatera");
            var bookingIdToUpdate = Convert.ToInt32(Console.ReadLine());
            var bookingToUpdate = dbContext.Bookings.First(p => p.Id == bookingIdToUpdate);
            Console.Clear();

            //fråga vad vill du göra
            //t.ex ändra datum

            //du har valt ändra datum


            //console write booking to update
            var inputDay = Convert.ToInt32(Console.ReadLine());
            var input = Convert.ToDateTime(Console.ReadLine());
            //if(bookingtoupdate != bookingToCreate){ for loop där du skickar in dem nya datumen.



            // convert input to date////////////// save
            dbContext.Bookings.First(b => b.Id == bookingToUpdate.Id).DateTimeStart = input;
            dbContext.Bookings.First(b => b.Id == bookingToUpdate.Id).DateTimeEnd = input.AddDays(inputDay);
            dbContext.SaveChanges();



        }
    }
}
