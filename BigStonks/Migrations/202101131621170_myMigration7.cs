namespace BigStonks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myMigration7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Portofolio_PortofolioId", c => c.Int());
            CreateIndex("dbo.Orders", "Portofolio_PortofolioId");
            AddForeignKey("dbo.Orders", "Portofolio_PortofolioId", "dbo.Portofolios", "PortofolioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Portofolio_PortofolioId", "dbo.Portofolios");
            DropIndex("dbo.Orders", new[] { "Portofolio_PortofolioId" });
            DropColumn("dbo.Orders", "Portofolio_PortofolioId");
        }
    }
}
