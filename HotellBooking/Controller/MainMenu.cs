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
            Console.WriteLine("Välj Vart du vill gå");
            Console.WriteLine("1: Gäster");
            Console.WriteLine("2: Rum");
            Console.WriteLine("3: Bokningar");
            Console.WriteLine("0: Exit");

            var sel = Convert.ToInt32(Console.ReadLine());

            return sel;
        }
    }
}
