using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BigStonks.Models
{
    public class Portofolio
    {
        public int PortofolioId { get; set; }

        [Required]
        [DefaultValue(50000)]
        [Range(0,Double.MaxValue)]
        public double AccountValue { get; set; }

        
        [Required]
        [DefaultValue(50000)]
        [Range(0, Double.MaxValue)]
        public double AvailableFunds { get; set; }

        public virtual ICollection<Position> Positions {get; set;}

        public virtual ICollection<Order> Orders { get; set; }
    }
}