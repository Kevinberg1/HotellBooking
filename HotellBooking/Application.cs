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
                        Console.WriteLine("Tack för idag");
                        return;
                    default:
                        Console.WriteLine("vänligen välj något altenativ");
                        break;
                }
                List<ICrud> actions = new List<ICrud>();

                var c = new CreateBooking(DbContext);
                //var r = new Read(DbContext);
                //var u = new Update(DbContext);
                //var d = new Delete(DbContext);

                //actions.Add(c);
                //actions.Add(r);
                //actions.Add(u);
                //actions.Add(d);
            }

        }

    }
}
