namespace BigStonks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my_migration3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Portofolio_PortofolioId", "dbo.Portofolios");
            DropIndex("dbo.AspNetUsers", new[] { "Portofolio_PortofolioId" });
            DropColumn("dbo.AspNetUsers", "Portofolio_PortofolioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Portofolio_PortofolioId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "Portofolio_PortofolioId");
            AddForeignKey("dbo.AspNetUsers", "Portofolio_PortofolioId", "dbo.Portofolios", "PortofolioId", cascadeDelete: true);
        }
    }
}
