namespace SalePizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewRelations_FluentAPIOut_Repair : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PurchaseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        BuyerId = c.Int(nullable: false),
                        PizzaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buyers", t => t.Id)
                .ForeignKey("dbo.Pizzas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Pizzas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Diameter = c.Double(),
                        Composition = c.String(maxLength: 150),
                        PurchaseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PizzaPurchases",
                c => new
                    {
                        Pizza_Id = c.Int(nullable: false),
                        Purchase_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pizza_Id, t.Purchase_Id })
                .ForeignKey("dbo.Pizzas", t => t.Pizza_Id, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.Purchase_Id, cascadeDelete: true)
                .Index(t => t.Pizza_Id)
                .Index(t => t.Purchase_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "Id", "dbo.Pizzas");
            DropForeignKey("dbo.PizzaPurchases", "Purchase_Id", "dbo.Purchases");
            DropForeignKey("dbo.PizzaPurchases", "Pizza_Id", "dbo.Pizzas");
            DropForeignKey("dbo.Purchases", "Id", "dbo.Buyers");
            DropIndex("dbo.PizzaPurchases", new[] { "Purchase_Id" });
            DropIndex("dbo.PizzaPurchases", new[] { "Pizza_Id" });
            DropIndex("dbo.Purchases", new[] { "Id" });
            DropTable("dbo.PizzaPurchases");
            DropTable("dbo.Pizzas");
            DropTable("dbo.Purchases");
            DropTable("dbo.Buyers");
        }
    }
}
