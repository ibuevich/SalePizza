namespace SalePizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPizzaMigration6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pizza", "Purchase_Id", "dbo.Purchase");
            DropIndex("dbo.Pizza", new[] { "Purchase_Id" });
            AddColumn("dbo.Pizza", "PurchaseId", c => c.Int());
            AlterColumn("dbo.Pizza", "Purchase_Id", c => c.Int());
            CreateIndex("dbo.Pizza", "PurchaseId");
            CreateIndex("dbo.Pizza", "Purchase_Id");
            AddForeignKey("dbo.Pizza", "PurchaseId", "dbo.Purchase", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pizza", "PurchaseId", "dbo.Purchase");
            DropIndex("dbo.Pizza", new[] { "Purchase_Id" });
            DropIndex("dbo.Pizza", new[] { "PurchaseId" });
            AlterColumn("dbo.Pizza", "Purchase_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Pizza", "PurchaseId");
            CreateIndex("dbo.Pizza", "Purchase_Id");
            AddForeignKey("dbo.Pizza", "Purchase_Id", "dbo.Purchase", "Id");
        }
    }
}
