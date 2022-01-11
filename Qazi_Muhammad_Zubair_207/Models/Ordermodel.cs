using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Qazi_Muhammad_Zubair_207.Models
{
    public class Ordermodel
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string descirption { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public double price { get; set; }

    }

}
