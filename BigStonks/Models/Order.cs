using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BigStonks.Models
{
    public class Order
    {

        public int OrderId { get; set; }

        [Required]
        public bool Filled { get; set; }

        [Required]
        public virtual Stock Stock { get; set; }
        
        [Required]
        public DateTime TimeOrdered { get; set; }

        [Required]
        public DateTime TimeFilled { get; set; }

        [Required]
        public double Ammount { get; set; }

        [Required]
        [RegularExpression("^(Limit|Market)$")]
        public string Type { get; set; }

        [Required]
        public double BuyPrice { get; set; }

        [Required]
        public double BuyTotal { get; set; }
    }
}