namespace BigStonks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myMigration1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Stocks", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "Name", c => c.String(nullable: false));
        }
    }
}
