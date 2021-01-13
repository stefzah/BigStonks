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
        public string Ticker { get; set; }


        //Pricing Data
        [Range(0, Double.MaxValue)]
        public double Open { get; set; }

        [Range(0, Double.MaxValue)]
        public double High { get; set; }

        [Range(0, Double.MaxValue)]
        public double Low { get; set; }

        [Required]
        [Range(0, Double.MaxValue)]
        public double Price { get; set; }

        [Range(0, Int32.MaxValue)]
        public int Volume { get; set; }

        [Range(0, Double.MaxValue)]
        public double PrevClose { get; set; }
        public double Change { get; set; }
        public double ChangePercent { get; set; }



        //Additional Info

        public string Name { get; set; }
        public string Description { get; set; }
        public string Exchange { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public string Sector { get; set; }
        public double BookValue { get; set; }
        public double EPS { get; set; }
        public double RevenuePerShareTTM { get; set; }
        public double ProfitMargin { get; set; }

    }
}