using HotellBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellBooking.Controller.Hotellroom
{
    public class CreateRoom : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }
        public CreateRoom(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("skapa ett Rum");
            Console.WriteLine("\n vad ska det vara för type? Dubbelrum/Enkelrum");
            var TypeInput = Console.ReadLine();
            Console.WriteLine("\n Hur många sängar");
            var BedInput =Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Skriv in rummets stolek (m2)");
            var Sizeinput = Convert.ToInt32( Console.ReadLine());

            dbContext.HotellRooms.Add(new HotellRoom()
            {
                Type = TypeInput,
                beds = BedInput,
                Size = Sizeinput
                
            });
            dbContext.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Rumet är nu Skapad");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n Tryck ENTER");
            Console.ReadLine();
            Console.Clear();


        }
    }
}

