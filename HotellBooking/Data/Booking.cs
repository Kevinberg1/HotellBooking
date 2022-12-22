using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellBooking.Data
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public HotellRoom HotellRoom { get; set; }
        public Guests Guests { get; set; }

        [Required]
        public DateTime DateTimeStart { get; set; }
        [Required]
        public DateTime DateTimeEnd { get; set; }
    }
}
