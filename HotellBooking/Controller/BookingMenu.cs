using HotellBooking.Controller.Booking;
using HotellBooking.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellBooking.Controller
{
    public class BookingMenu : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }

        public BookingMenu(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Run()

        {
            var buildApp = new Build();
            var DbContext = buildApp.BuildApp();
            bool menu = true;
            while (menu)
            {
                Console.Clear();
                Console.WriteLine("här väljer du vad du vill göra med dina bokningar");
                Console.WriteLine("1: Create: Booking");
                Console.WriteLine("2: Read: Booking");
                Console.WriteLine("3: Update: Booking");
                Console.WriteLine("4: Delete: Booking");
                Console.WriteLine("0: Tillbaka till huvudmeny");

                var sel = Convert.ToInt32(Console.ReadLine());

                switch (sel)
                {
                    case 1:
                        var action = new CreateBooking(DbContext);
                        action.Run();
                        break;
                    case 2:
                        var action1 = new ReadBooking(DbContext);
                        action1.Run();
                        break;
                    case 3:
                        var action3 = new UpdateBooking(DbContext);
                        action3.Run();
                        break;
                    case 4:
                        var action4 = new Deletebooking(DbContext);
                        action4.Run();
                        break;

                    case 0:
                        return;
                    default:
                        Console.WriteLine("vänligen välj något altenativ");
                        break;
                }

            }
        }
    }
}

