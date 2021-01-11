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
        public double AccountValue { get; set; }

        [DefaultValue(50000)]
        [Required]
        public double AvailableFunds { get; set; }

        public virtual ICollection<Position> Positions {get; set;}
    }
}