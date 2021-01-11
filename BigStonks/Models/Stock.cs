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

        public double Open { get; set; }

        public double High { get; set; }

        public double Low { get; set; }

        [Required]
        public double Price { get; set; }

        public int Volume { get; set; }
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
        public double PERatio { get; set; }
        public double PEGRatio { get; set; }
        public double BookValue { get; set; }
        public double DividendPerShare { get; set; }
        public double DividendYield { get; set; }
        public double EPS { get; set; }
        public double RevenuePerShareTTM { get; set; }
        public double ProfitMargin { get; set; }

    }
}