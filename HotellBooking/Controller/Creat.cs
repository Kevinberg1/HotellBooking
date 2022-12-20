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
    public class Creat : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }

        public Creat(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Run()
        {
            
                var bookingToCreate = new Booking();
                Console.Clear();
                Console.WriteLine(" Hur många dagar vill du booka ?");
                int numberOfDays = Convert.ToInt32(Console.ReadLine());

                bookingToCreate.DateTimeStart = new DateTime(2001, 01, 01, 23, 59, 59);
                while (bookingToCreate.DateTimeStart < DateTime.Now.Date)
                {
                    Console.WriteLine("\n vilken dag vill du att det ska börja gälla? (yyyy-mm-dd)");
                    bookingToCreate.DateTimeStart = Convert.ToDateTime(Console.ReadLine());
                }

                if (numberOfDays == 1) bookingToCreate.DateTimeEnd = bookingToCreate.DateTimeStart;
                else if (numberOfDays > 1) bookingToCreate.DateTimeEnd = bookingToCreate.DateTimeStart.AddDays(numberOfDays);

                // Now we need to create a list of available cars for the user to choose from.
                // Lets start by making a list of ALL the dates included in the new booking
                List<DateTime> newBookingAllDates = new List<DateTime>();
                for (var dt = bookingToCreate.DateTimeStart; dt <= bookingToCreate.DateTimeEnd; dt = dt.AddDays(1))
                {
                    newBookingAllDates.Add(dt);
                }

                // Lets loop through all the cars in the system 
                // and check if they have booking dates that block our new booking,
                List<HotellRoom> availableRooms = new List<HotellRoom>();

                foreach (var rum in dbContext.HotellRooms.ToList())
                {
                    bool RoomsFree = true;
                    foreach (var booking in dbContext.Bookings.Include(b => b.room)
                                 .Where(b => b.room == rum))
                    {
                        for (var dt = booking.DateTimeStart; dt <= booking.DateTimeEnd; dt = dt.AddDays(1))
                        {
                            if (newBookingAllDates.Contains(dt))
                            {
                                RoomsFree = false;

                            }
                        }

                        // if the car is already booked on the date of the new booking...
                        // we dont need to check any of the other bookings... the car isnt available
                        // so we break out of the loop and check the next car
                        if (!RoomsFree)
                        {
                            break;
                        }
                    }


                    // finally if the car is free we can add it to our list of available cars
                    if (RoomsFree)
                    {
                        availableRooms.Add(rum);
                    }
                }

                // Lets show the bookings details
                Console.Clear();
                Console.WriteLine(" Your booking details");
                Console.WriteLine(" ==================================================================");
                Console.WriteLine(" Start\t\tEnd\t\tNo. of days");
                Console.WriteLine(
                    $" {bookingToCreate.DateTimeStart.ToShortDateString()}\t{bookingToCreate.DateTimeEnd.ToShortDateString()}\t{numberOfDays}");

                // FAIL! Display if no avaialable cars
                if (availableRooms.Count() < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n There are no cars available for these dates. Please try another date");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.WriteLine(" Press any key to continue");
                    Console.ReadLine();
                    return; // end method
                }
                else
                {
                    // Display the available cars
                    Console.WriteLine("\n\n\n These cars are available for booking");
                    Console.WriteLine("\n License Plate\tMake\t\tModel");
                    Console.WriteLine(" ==================================================================");

                    foreach (var rum in availableRooms.OrderBy(r => r.Id))
                    {
                        Console.WriteLine($" {rum.Id}\t");
                        Console.WriteLine(" ------------------------------------------------------------------");
                    }
                }

                // Assign the car the user chose to the booking 
                Console.WriteLine("\n Please choose a car (license plate) from the available cars");
                string roomsforbooking = Console.ReadLine();
                bookingToCreate.room = dbContext.HotellRooms
                    .Where(c => c.Id == roomsforbooking)
                    .FirstOrDefault();

                dbContext.Add(bookingToCreate);
                dbContext.SaveChanges();

                // SUCCESS!
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.WriteLine(" Booking successful!");
                Console.WriteLine(" ==============================================================================");
                Console.WriteLine(" Start\t\tEnd\t\tNo. of days");
                Console.WriteLine(
                    $" {bookingToCreate.DateTimeStart.ToShortDateString()}\t{bookingToCreate.DateTimeEnd.ToShortDateString()}\t{numberOfDays}");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine("\n Press any key to continue");
                Console.ReadLine();
            
        }
    }
}
