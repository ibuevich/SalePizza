namespace SalePizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewRelations_FluentAPIOut_Repair_Last : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Buyers", "PurchaseId", c => c.Int());
            AlterColumn("dbo.Pizzas", "PurchaseId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pizzas", "PurchaseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Buyers", "PurchaseId", c => c.Int(nullable: false));
        }
    }
}
