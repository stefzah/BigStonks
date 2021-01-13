namespace BigStonks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myMigration4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Stocks", "PEGRatio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "PEGRatio", c => c.Double(nullable: false));
        }
    }
}
