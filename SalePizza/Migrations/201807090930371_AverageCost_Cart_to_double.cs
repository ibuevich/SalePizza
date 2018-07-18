namespace SalePizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AverageCost_Cart_to_double : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cart", "AverageCost", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cart", "AverageCost", c => c.Int(nullable: false));
        }
    }
}
