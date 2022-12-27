using HotellBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellBooking.Controller.Guest
{
    public class CreateGuest : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }
        public CreateGuest(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void Run()
        {
            Console.Clear();


            Console.WriteLine("skapa en perosn");
            Console.WriteLine("\n vad heter du? (Förnamn)");
            var nameInput = Console.ReadLine();
            Console.WriteLine("\n vad heter du? (Efternamn)");
            var LastnameInput = Console.ReadLine();

            dbContext.Guests.Add(new Guests()
            {
                Name = nameInput,
                LastName = LastnameInput
                //Lägg till mer
            });
            dbContext.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Gästen är nu Skapad");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n Tryck ENTER");
            Console.ReadLine();
            Console.Clear();


        }
}
}
