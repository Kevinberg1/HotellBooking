using HotellBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellBooking.Controller.Guest
{
    public class UpdateGuest : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }

        public UpdateGuest(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Run()
        {
            Console.Clear();


            Console.WriteLine("ändra befintliga Gäster");
            foreach (var person in dbContext.Guests)
            {
                Console.WriteLine($"Id: {person.Id}");
                Console.WriteLine($"Namn: {person.Name} {person.LastName}");
                Console.WriteLine("====================");
            }

            Console.WriteLine("Välj Id på den Person som du vill uppdatera");
            var personIdToUpdate = Convert.ToInt32(Console.ReadLine());
            var personToUpdate = dbContext.Guests.First(p => p.Id == personIdToUpdate);
            Console.Clear();

            Console.WriteLine("Ange nya namn: ");
            var nameUpdate = Console.ReadLine();

            Console.WriteLine("Ange nya Efternamn: ");
            var lastNameUpdate = Console.ReadLine();


            
            personToUpdate.Name = nameUpdate;
            personToUpdate.LastName = lastNameUpdate;
            dbContext.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Gästen är nu Updaterad");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\n Tryck ENTER");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

