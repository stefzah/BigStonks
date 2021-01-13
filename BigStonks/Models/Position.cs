using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BigStonks.Models
{
    public class Position
    {
        public int PositionId { get; set; }

        [Required]
        public virtual Stock Stock { get; set; }
        
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }

        [Required(ErrorMessage = "Enter how many stocks baught")]
        public int Ammount { get; set; }

        [Required]
        public double InitialPrice { get; set; }

        [Required]
        public double InitialCost { get; set; }

    }
}