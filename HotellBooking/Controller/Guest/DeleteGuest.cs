using HotellBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellBooking.Controller.Guest
{
    public class DeleteGuest : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }

        public DeleteGuest(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Run()
        {
            Console.Clear();


            Console.WriteLine("Ta bort en Gäst, vilken ?");
            foreach (var person in dbContext.Guests)
            {
                Console.WriteLine($"Id: {person.Id}");
                Console.WriteLine($"Namn: {person.Name} {person.LastName}");
                Console.WriteLine("====================");
            }

            Console.WriteLine("Välj Id på den Gäst som du vill radera");
            var personIdToDelete = Convert.ToInt32(Console.ReadLine());
            var personToDelete = dbContext.Guests.First(p => p.Id == personIdToDelete);
            dbContext.Guests.Remove(personToDelete);
            dbContext.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Gästen är nu raderad från systemet");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n Tryck ENTER");
            Console.ReadLine();
            Console.Clear();
        }
    }
}