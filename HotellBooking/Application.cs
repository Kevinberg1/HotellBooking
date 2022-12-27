using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotellBooking.Controller;
using HotellBooking.Controller.Booking;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HotellBooking
{
    public class Application
    {
        public void Run()
        {
            var buildApp = new Build();
            var DbContext = buildApp.BuildApp();
            bool menu = true;
            while (menu)
            {
                var sel = MainMenu.ShowMenu();

                switch (sel)
                {
                    case 1:
                        var action = new GuestMenu(DbContext);
                        action.Run();
                        Console.Clear();
                        break;
                    case 2:
                        var action1 = new RoomMenu(DbContext);
                        action1.Run();
                        Console.Clear();
                        break;
                    case 3:
                        var action3 = new BookingMenu(DbContext);
                        action3.Run();
                        Console.Clear();
                        break;

                    case 0:
                        Console.WriteLine("Tack för idag");
                        return;
                    default:
                        Console.WriteLine("vänligen välj något altenativ");
                        break;
                }
            }

        }

    }
}
