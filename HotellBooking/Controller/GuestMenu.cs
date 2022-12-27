using HotellBooking.Controller.Booking;
using HotellBooking.Controller.Guest;
using HotellBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellBooking.Controller
{
    public class GuestMenu : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }

        public GuestMenu(ApplicationDbContext context)
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
                Console.WriteLine("här väljer du vad du vill göra med dina Gäster");
                Console.WriteLine("1: Create: Guest");
                Console.WriteLine("2: Read: Guest");
                Console.WriteLine("3: Update: Guest");
                Console.WriteLine("4: Delete: guest");
                Console.WriteLine("0: Tillbaka till huvudmeny");

                var sel = Convert.ToInt32(Console.ReadLine());

                switch (sel)
                {
                    case 1:
                        var action = new CreateGuest(DbContext);
                        action.Run();
                        break;
                    case 2:
                        var action1 = new ReadGuest(DbContext);
                        action1.Run();
                        break;
                    case 3:
                        var action3 = new UpdateGuest(DbContext);
                        action3.Run();
                        break;
                    case 4:
                        var action4 = new DeleteGuest(DbContext);
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

