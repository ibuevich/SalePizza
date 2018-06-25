namespace SalePizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPizzaMigration3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Buyers", newName: "Buyer");
            RenameTable(name: "dbo.Pizzas", newName: "Pizza");
            RenameTable(name: "dbo.Purchases", newName: "Purchase");
            RenameColumn(table: "dbo.Buyer", name: "Name", newName: "BuyerName");
            RenameColumn(table: "dbo.Pizza", name: "Name", newName: "PizzaName");
            RenameColumn(table: "dbo.Pizza", name: "Diameter", newName: "Size");
            RenameColumn(table: "dbo.Pizza", name: "Composition", newName: "Description");
            RenameColumn(table: "dbo.Purchase", name: "Date", newName: "DateOfPurchase");
            RenameColumn(table: "dbo.Purchase", name: "Price", newName: "PriceOfPizza");
            AddColumn("dbo.Pizza", "Purchase_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Purchase", "Buyer_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Buyer", "BuyerName", c => c.String(nullable: false));
            AlterColumn("dbo.Pizza", "PizzaName", c => c.String(nullable: false));
            AlterColumn("dbo.Pizza", "Size", c => c.Double());
            AlterColumn("dbo.Pizza", "Description", c => c.String());
            CreateIndex("dbo.Purchase", "PizzaId");
            CreateIndex("dbo.Purchase", "Buyer_Id");
            CreateIndex("dbo.Pizza", "Purchase_Id");
            AddForeignKey("dbo.Purchase", "PizzaId", "dbo.Pizza", "Id");
            AddForeignKey("dbo.Pizza", "Purchase_Id", "dbo.Purchase", "Id");
            AddForeignKey("dbo.Purchase", "Buyer_Id", "dbo.Buyer", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchase", "Buyer_Id", "dbo.Buyer");
            DropForeignKey("dbo.Pizza", "Purchase_Id", "dbo.Purchase");
            DropForeignKey("dbo.Purchase", "PizzaId", "dbo.Pizza");
            DropIndex("dbo.Pizza", new[] { "Purchase_Id" });
            DropIndex("dbo.Purchase", new[] { "Buyer_Id" });
            DropIndex("dbo.Purchase", new[] { "PizzaId" });
            AlterColumn("dbo.Pizza", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Pizza", "Size", c => c.Double(nullable: false));
            AlterColumn("dbo.Pizza", "PizzaName", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Buyer", "BuyerName", c => c.String(nullable: false, maxLength: 60));
            DropColumn("dbo.Purchase", "Buyer_Id");
            DropColumn("dbo.Pizza", "Purchase_Id");
            RenameColumn(table: "dbo.Purchase", name: "PriceOfPizza", newName: "Price");
            RenameColumn(table: "dbo.Purchase", name: "DateOfPurchase", newName: "Date");
            RenameColumn(table: "dbo.Pizza", name: "Description", newName: "Composition");
            RenameColumn(table: "dbo.Pizza", name: "Size", newName: "Diameter");
            RenameColumn(table: "dbo.Pizza", name: "PizzaName", newName: "Name");
            RenameColumn(table: "dbo.Buyer", name: "BuyerName", newName: "Name");
            RenameTable(name: "dbo.Purchase", newName: "Purchases");
            RenameTable(name: "dbo.Pizza", newName: "Pizzas");
            RenameTable(name: "dbo.Buyer", newName: "Buyers");
        }
    }
}
