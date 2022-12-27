using HotellBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellBooking.Controller.Hotellroom
{
    public class DeleteRoom : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }

        public DeleteRoom(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("Ta bort ett Rum, vilken ?");
            foreach (var r in dbContext.HotellRooms)
            {
                Console.WriteLine($"Id: {r.Id}");
                Console.WriteLine($"Namn: {r.Type} {r.beds}");
                Console.WriteLine("====================");
            }

            Console.WriteLine("Välj Id på den Rum som du vill radera");
            var roomIdToDelete = Convert.ToInt32(Console.ReadLine());
            var roomToDelete = dbContext.HotellRooms.First(p => p.Id == roomIdToDelete);
            dbContext.HotellRooms.Remove(roomToDelete);
            dbContext.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Rummet är nu raderad från systemet");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n Tryck ENTER");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
