using HotellBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellBooking.Controller.Hotellroom
{

    public class UpdateRoom : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }

        public UpdateRoom(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Run()
        {
            Console.Clear();


            Console.WriteLine("ändra befintligt Rum");
            foreach (var r in dbContext.HotellRooms)
            {
                Console.WriteLine($"Id: {r.Id}");
                Console.WriteLine($"Type/Beds: {r.Type} / {r.beds}");
                Console.WriteLine("====================");
            }

            Console.WriteLine("Välj Id på den Rum som du vill uppdatera");
            var RoomIdToUpdate = Convert.ToInt32(Console.ReadLine());
            var RoomToUpdate = dbContext.HotellRooms.First(p => p.Id == RoomIdToUpdate);
            Console.Clear();

            Console.WriteLine("vad ska det vara för type? Dubbelrum/Enkelrum");
            var TypeUpdate = Console.ReadLine();

            Console.WriteLine("Ange hur många nya sängar: ");
            var bedUpdate = Convert.ToInt32(Console.ReadLine());



            RoomToUpdate.Type = TypeUpdate;
            RoomToUpdate.beds = bedUpdate;
            dbContext.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Rumet är nu Updaterad");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\n Tryck ENTER");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

