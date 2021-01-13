namespace BigStonks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myMigration9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "Total", c => c.Double(nullable: false));
            DropColumn("dbo.Orders", "BuyPrice");
            DropColumn("dbo.Orders", "BuyTotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "BuyTotal", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "BuyPrice", c => c.Double(nullable: false));
            DropColumn("dbo.Orders", "Total");
            DropColumn("dbo.Orders", "Price");
        }
    }
}
