using HotellBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellBooking.Controller.Hotellroom
{
    public class ReadRoom : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }

        public ReadRoom(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Run()
        {
            Console.Clear();

            Console.WriteLine("här är alla Rum: ");


            foreach (var r in dbContext.HotellRooms)
            {
                Console.WriteLine($"Type: {r.Type}");
                Console.WriteLine($"Sängar: {r.beds} st");
                Console.WriteLine($"Stolek: {r.Size} m2");
                Console.WriteLine("---------------------------");

                //Lägg till mer
            }
            Console.WriteLine("\n Tryck ENTER");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

