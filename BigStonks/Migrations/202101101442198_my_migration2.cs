namespace BigStonks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my_migration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "EnableDarkMode", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Portofolio_PortofolioId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "Portofolio_PortofolioId");
            AddForeignKey("dbo.AspNetUsers", "Portofolio_PortofolioId", "dbo.Portofolios", "PortofolioId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Portofolio_PortofolioId", "dbo.Portofolios");
            DropIndex("dbo.AspNetUsers", new[] { "Portofolio_PortofolioId" });
            DropColumn("dbo.AspNetUsers", "Portofolio_PortofolioId");
            DropColumn("dbo.AspNetUsers", "EnableDarkMode");
        }
    }
}
