using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BigStonks.Models
{
    public class Stock
    {
        public int StockId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Ticker { get; set; }

        [Required]
        public double Price { get; set; }
        
    }
}