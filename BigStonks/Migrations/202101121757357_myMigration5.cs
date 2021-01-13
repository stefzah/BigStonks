namespace BigStonks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myMigration5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Stocks", "DividendPerShare");
            DropColumn("dbo.Stocks", "DividendYield");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "DividendYield", c => c.Double(nullable: false));
            AddColumn("dbo.Stocks", "DividendPerShare", c => c.Double(nullable: false));
        }
    }
}
