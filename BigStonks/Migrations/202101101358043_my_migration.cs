namespace BigStonks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Filled = c.Boolean(nullable: false),
                        TimeOrdered = c.DateTime(nullable: false),
                        TimeFilled = c.DateTime(nullable: false),
                        Ammount = c.Double(nullable: false),
                        Type = c.String(nullable: false),
                        BuyPrice = c.Double(nullable: false),
                        BuyTotal = c.Double(nullable: false),
                        Stock_StockId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Stocks", t => t.Stock_StockId, cascadeDelete: true)
                .Index(t => t.Stock_StockId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        StockId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Ticker = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.StockId);
            
            CreateTable(
                "dbo.Portofolios",
                c => new
                    {
                        PortofolioId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.PortofolioId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        PurchaseDate = c.DateTime(nullable: false),
                        Ammount = c.Int(nullable: false),
                        InitialPrice = c.Double(nullable: false),
                        InitialCost = c.Double(nullable: false),
                        Stock_StockId = c.Int(nullable: false),
                        Portofolio_PortofolioId = c.Int(),
                    })
                .PrimaryKey(t => t.PositionId)
                .ForeignKey("dbo.Stocks", t => t.Stock_StockId, cascadeDelete: true)
                .ForeignKey("dbo.Portofolios", t => t.Portofolio_PortofolioId)
                .Index(t => t.Stock_StockId)
                .Index(t => t.Portofolio_PortofolioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Positions", "Portofolio_PortofolioId", "dbo.Portofolios");
            DropForeignKey("dbo.Positions", "Stock_StockId", "dbo.Stocks");
            DropForeignKey("dbo.Orders", "Stock_StockId", "dbo.Stocks");
            DropIndex("dbo.Positions", new[] { "Portofolio_PortofolioId" });
            DropIndex("dbo.Positions", new[] { "Stock_StockId" });
            DropIndex("dbo.Orders", new[] { "Stock_StockId" });
            DropTable("dbo.Positions");
            DropTable("dbo.Portofolios");
            DropTable("dbo.Stocks");
            DropTable("dbo.Orders");
        }
    }
}
