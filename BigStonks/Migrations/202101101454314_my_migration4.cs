namespace BigStonks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my_migration4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Portofolio_PortofolioId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Portofolio_PortofolioId");
            AddForeignKey("dbo.AspNetUsers", "Portofolio_PortofolioId", "dbo.Portofolios", "PortofolioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Portofolio_PortofolioId", "dbo.Portofolios");
            DropIndex("dbo.AspNetUsers", new[] { "Portofolio_PortofolioId" });
            DropColumn("dbo.AspNetUsers", "Portofolio_PortofolioId");
        }
    }
}
