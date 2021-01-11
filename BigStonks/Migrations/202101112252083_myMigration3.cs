namespace BigStonks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myMigration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stocks", "High", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "Low", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "PrevClose", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "Change", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "ChangePercent", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "Name", c => c.String());
            AddColumn("dbo.Stocks", "Description", c => c.String());
            AddColumn("dbo.Stocks", "Exchange", c => c.String());
            AddColumn("dbo.Stocks", "Currency", c => c.String());
            AddColumn("dbo.Stocks", "Country", c => c.String());
            AddColumn("dbo.Stocks", "Sector", c => c.String());
            AddColumn("dbo.Stocks", "EPS", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "RevenuePerShareTTM", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "ProfitMargin", c => c.Double(nullable: false));
            DropColumn("dbo.Stocks", "Bid");
            DropColumn("dbo.Stocks", "Ask");
            DropColumn("dbo.Stocks", "PreviousClose");
            DropColumn("dbo.Stocks", "WeekHigh52");
            DropColumn("dbo.Stocks", "WeekLow52");
            DropColumn("dbo.Stocks", "WeekLowChange52");
            DropColumn("dbo.Stocks", "WeekHighChange52");
            DropColumn("dbo.Stocks", "WeekLowChange52Percent");
            DropColumn("dbo.Stocks", "WeekHighChange52Percent");
            DropColumn("dbo.Stocks", "WeekRange52");
            DropColumn("dbo.Stocks", "DividentPayDate");
            DropColumn("dbo.Stocks", "ExDividentDate");
            DropColumn("dbo.Stocks", "AskSize");
            DropColumn("dbo.Stocks", "BidSize");
            DropColumn("dbo.Stocks", "LastTradeSize");
            DropColumn("dbo.Stocks", "AverageDailyVolume");
            DropColumn("dbo.Stocks", "DayLow");
            DropColumn("dbo.Stocks", "DayHigh");
            DropColumn("dbo.Stocks", "LastTradePrice");
            DropColumn("dbo.Stocks", "DayMovingAverage50");
            DropColumn("dbo.Stocks", "DayMovingAverage200");
            DropColumn("dbo.Stocks", "OneYearTargetPrice");
            DropColumn("dbo.Stocks", "EarningsPerShare");
            DropColumn("dbo.Stocks", "EPSEstimateNextYear");
            DropColumn("dbo.Stocks", "EPSEstimateCurrentYear");
            DropColumn("dbo.Stocks", "EPSEstimateNextQuarter");
            DropColumn("dbo.Stocks", "EBITDA");
            DropColumn("dbo.Stocks", "PriceSales");
            DropColumn("dbo.Stocks", "PriceBook");
            DropColumn("dbo.Stocks", "PERatioRealTime");
            DropColumn("dbo.Stocks", "PriceEPSEstimateCurrentYear");
            DropColumn("dbo.Stocks", "PriceEPSEstimateNextYear");
            DropColumn("dbo.Stocks", "ShortRatio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "ShortRatio", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "PriceEPSEstimateNextYear", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "PriceEPSEstimateCurrentYear", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "PERatioRealTime", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "PriceBook", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "PriceSales", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "EBITDA", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "EPSEstimateNextQuarter", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "EPSEstimateCurrentYear", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "EPSEstimateNextYear", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "EarningsPerShare", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "OneYearTargetPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "DayMovingAverage200", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "DayMovingAverage50", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "LastTradePrice", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "DayHigh", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "DayLow", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "AverageDailyVolume", c => c.Int(nullable: false));
            AddColumn("dbo.Stocks", "LastTradeSize", c => c.Int(nullable: false));
            AddColumn("dbo.Stocks", "BidSize", c => c.Int(nullable: false));
            AddColumn("dbo.Stocks", "AskSize", c => c.Int(nullable: false));
            AddColumn("dbo.Stocks", "ExDividentDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stocks", "DividentPayDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stocks", "WeekRange52", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "WeekHighChange52Percent", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "WeekLowChange52Percent", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "WeekHighChange52", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "WeekLowChange52", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "WeekLow52", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "WeekHigh52", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "PreviousClose", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "Ask", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "Bid", c => c.Double(nullable: false));
            DropColumn("dbo.Stocks", "ProfitMargin");
            DropColumn("dbo.Stocks", "RevenuePerShareTTM");
            DropColumn("dbo.Stocks", "EPS");
            DropColumn("dbo.Stocks", "Sector");
            DropColumn("dbo.Stocks", "Country");
            DropColumn("dbo.Stocks", "Currency");
            DropColumn("dbo.Stocks", "Exchange");
            DropColumn("dbo.Stocks", "Description");
            DropColumn("dbo.Stocks", "Name");
            DropColumn("dbo.Stocks", "ChangePercent");
            DropColumn("dbo.Stocks", "Change");
            DropColumn("dbo.Stocks", "PrevClose");
            DropColumn("dbo.Stocks", "Price");
            DropColumn("dbo.Stocks", "Low");
            DropColumn("dbo.Stocks", "High");
        }
    }
}
