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
            Console.WriteLine("choose what you want to do!");
            Console.WriteLine("1: Create: Booking/guest/room");
            Console.WriteLine("2: Read: Booking/guest/room");
            Console.WriteLine("3: Update: Booking/guest/room");
            Console.WriteLine("4: Delete: Booking/guest/room");
            Console.WriteLine("0: Exit");

            var sel = Convert.ToInt32(Console.ReadLine());

            return sel;
        }
    }
}
