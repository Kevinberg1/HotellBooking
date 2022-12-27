using HotellBooking.Controller.Guest;
using HotellBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotellBooking.Controller.Hotellroom;

namespace HotellBooking.Controller
{
    public class RoomMenu : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }

        public RoomMenu(ApplicationDbContext context)
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
                Console.WriteLine("här väljer du vad du vill göra med dina Rum");
                Console.WriteLine("1: Create: Rum");
                Console.WriteLine("2: Read: Rum");
                Console.WriteLine("3: Update: Rum");
                Console.WriteLine("4: Delete: Rum");
                Console.WriteLine("0: Tillbaka till huvudmeny");

                var sel = Convert.ToInt32(Console.ReadLine());

                switch (sel)
                {
                    case 1:
                        var action = new CreateRoom(DbContext);
                        action.Run();
                        break;
                    case 2:
                        var action1 = new ReadRoom(DbContext);
                        action1.Run();
                        break;
                    case 3:
                        var action3 = new UpdateRoom(DbContext);
                        action3.Run();
                        break;
                    case 4:
                        var action4 = new DeleteRoom(DbContext);
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

