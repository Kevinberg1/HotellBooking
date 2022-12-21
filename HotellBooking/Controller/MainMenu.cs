using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellBooking.Controller
{
    public class MainMenu
    {
        public static int ShowMenu()
        {
            Console.WriteLine("1:Boka rum");
            Console.WriteLine("2: se alla bokingar");
            Console.WriteLine("3: (U) Update");
            Console.WriteLine("4: (D) Delete");
            Console.WriteLine("0: Exit");

            var sel = Convert.ToInt32(Console.ReadLine());

            return sel;
        }
    }
}
