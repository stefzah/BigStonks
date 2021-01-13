namespace BigStonks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myMigration8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Ammount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Ammount", c => c.Double(nullable: false));
        }
    }
}
