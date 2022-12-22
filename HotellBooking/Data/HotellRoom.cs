using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellBooking.Data
{
    public class HotellRoom
    {
        [Key]
        
        public int Id { get; set; }

        

        [Required]
        public string Type { get; set; }


        [Required]
        public int beds { get; set; }

        


    }
}
