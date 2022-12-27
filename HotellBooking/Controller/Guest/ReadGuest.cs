using HotellBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellBooking.Controller.Guest
{
    public class ReadGuest : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }

        public ReadGuest(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Run()
        {
            Console.Clear();

            Console.WriteLine("här är alla Gäster: ");


            foreach (var person in dbContext.Guests)
            {
                Console.WriteLine($"Namn: {person.Name}");
                Console.WriteLine($"Efternamn: {person.LastName}");
                Console.WriteLine("---------------------------");

                //Lägg till mer
            }
            Console.WriteLine("\n Tryck ENTER");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
