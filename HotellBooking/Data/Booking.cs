using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellBooking.Data
{
    public class Booking
    {
        public int Id { get; set; }
        public HotellRoom room { get; set; }
        public Guests Guests { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
    }
}
