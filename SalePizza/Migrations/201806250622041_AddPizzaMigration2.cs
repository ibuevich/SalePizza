namespace SalePizza.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddPizzaMigration2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Buers", newName: "Buyers");
            DropForeignKey("dbo.Purchases", "BuerId", "dbo.Buers");
            DropForeignKey("dbo.Purchases", "PizzaId", "dbo.Pizzas");
            DropIndex("dbo.Purchases", new[] { "PizzaId" });
            DropIndex("dbo.Purchases", new[] { "BuerId" });
            AddColumn("dbo.Purchases", "BuyerId", c => c.Int(nullable: false));
            DropColumn("dbo.Purchases", "BuerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchases", "BuerId", c => c.Int(nullable: false));
            DropColumn("dbo.Purchases", "BuyerId");
            CreateIndex("dbo.Purchases", "BuerId");
            CreateIndex("dbo.Purchases", "PizzaId");
            AddForeignKey("dbo.Purchases", "PizzaId", "dbo.Pizzas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Purchases", "BuerId", "dbo.Buers", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Buyers", newName: "Buers");
        }
    }
}
