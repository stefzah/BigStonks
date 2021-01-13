namespace BigStonks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myMigration6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Stocks", "PERatio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "PERatio", c => c.Double(nullable: false));
        }
    }
}
