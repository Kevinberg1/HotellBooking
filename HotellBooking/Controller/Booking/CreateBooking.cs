using HotellBooking.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace HotellBooking.Controller
{
    public class CreateBooking : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }

        public CreateBooking(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Run()
        {

            var bookingToCreate = new Data.Booking();

            // Check what the guest wants
            Console.Clear();
            Console.WriteLine(" Hur många dagar vill du stanna?");
            int numberOfDays = Convert.ToInt32(Console.ReadLine());

            // Keep asking for a valid date in the future
            bookingToCreate.DateTimeStart = new DateTime(2001, 01, 01, 23, 59, 59);
            while (bookingToCreate.DateTimeStart < DateTime.Now.Date)
            {
                Console.WriteLine("\n från och med vilken dag vill du boka? (yyyy-mm-dd)");
                bookingToCreate.DateTimeStart = Convert.ToDateTime(Console.ReadLine());
            }

            // set dateEnd
            if (numberOfDays == 1) bookingToCreate.DateTimeEnd = bookingToCreate.DateTimeStart;
            else if (numberOfDays > 1)
                bookingToCreate.DateTimeEnd = bookingToCreate.DateTimeStart.AddDays(numberOfDays);

            // Now we need to create a list of available cars for the user to choose from.
            // Lets start by making a list of ALL the dates included in the new booking
            List<DateTime> newBookingAllDates = new List<DateTime>();
            for (var dt = bookingToCreate.DateTimeStart; dt <= bookingToCreate.DateTimeEnd; dt = dt.AddDays(1))
            {
                newBookingAllDates.Add(dt);
            }

            // Lets loop through all the cars in the system 
            // and check if they have booking dates that block our new booking,
            List<HotellRoom> avaliblerooms = new List<HotellRoom>();

            foreach (var room in dbContext.HotellRooms.ToList())
            {
                bool freeRoom = true;
                foreach (var booking in dbContext.Bookings.Include(b => b.HotellRoom)
                             .Where(b => b.HotellRoom == room))
                {

                    for (var dt = booking.DateTimeStart; dt <= booking.DateTimeEnd; dt = dt.AddDays(1))
                    {
                        if (newBookingAllDates.Contains(dt))
                        {
                            freeRoom = false;

                        }
                    }

                    // if the car is already booked on the date of the new booking...
                    // we dont need to check any of the other bookings... the car isnt available
                    // so we break out of the loop and check the next car
                    if (!freeRoom)
                    {
                        break;
                    }
                }


                // finally if the car is free we can add it to our list of available cars
                if (freeRoom)
                {
                    avaliblerooms.Add(room);
                }
            }

            // Lets show the bookings details
            Console.Clear();
            Console.WriteLine(" Booknings information");
            Console.WriteLine(" ==================================================================");
            Console.WriteLine(" Start\t\tEnd\t\tNo. of days");
            Console.WriteLine(
                $" {bookingToCreate.DateTimeStart.ToShortDateString()}\t{bookingToCreate.DateTimeEnd.ToShortDateString()}\t{numberOfDays}");

            // FAIL! Display if no avaialable cars
            if (avaliblerooms.Count() < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n det finns inga lediga rum på detta datum");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine(" tryck för att gå vidare");
                Console.ReadLine();
                return; // end method
            }
            else
            {
                // Display the available cars
                Console.WriteLine("\n\n\n dessa rum är lediga");
                Console.WriteLine("\n Hotell nr\t typ\t\tantal sängar");
                Console.WriteLine(" ==================================================================");

                foreach (var room in avaliblerooms.OrderBy(r => r.Id))
                {
                    Console.WriteLine($" {room.Id}\t\t{room.Type}\t\t{room.beds}");
                    Console.WriteLine(" ------------------------------------------------------------------");
                }
            }
            /////////////här är det fel

            // Assign the car the user chose to the booking 
            Console.WriteLine("\n välj vilket rum nummer du vill ha");
            var SelectedRoomId = Convert.ToInt32(Console.ReadLine());

            bookingToCreate.HotellRoom = dbContext.HotellRooms
                .Where(c => c.Id == SelectedRoomId)
                .FirstOrDefault();

            foreach (var guest in dbContext.Guests)
            {
                Console.WriteLine($" {guest.Id} {guest.Name}");
                Console.WriteLine(" ------------------------------------------------------------------");
            }
            var SelectGuest = Convert.ToInt32(Console.ReadLine());
            
            bookingToCreate.Guests = dbContext.Guests.Where(c => c.Id == SelectGuest).FirstOrDefault();

            dbContext.Bookings.Add(bookingToCreate);
            
            dbContext.SaveChanges();

            // SUCCESS!
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine(" bookningen ser ut såhär");
            Console.WriteLine(" Start\t\tEnd\t\tNo. of days");
            Console.WriteLine(
                $" {bookingToCreate.DateTimeStart.ToShortDateString()}\t{bookingToCreate.DateTimeEnd.ToShortDateString()}\t{numberOfDays}");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\n använd tangenbortet för att gå vidare");
            Console.ReadLine();
        }
    }

}

