namespace BigStonks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my_migration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Portofolios", "AccountValue", c => c.Double(nullable: false));
            AddColumn("dbo.Portofolios", "AvailableFunds", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Portofolios", "AvailableFunds");
            DropColumn("dbo.Portofolios", "AccountValue");
        }
    }
}
