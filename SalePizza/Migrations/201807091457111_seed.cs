namespace SalePizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seed : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Cart", newName: "Carts");
            RenameTable(name: "dbo.ApplicationUser", newName: "ApplicationUsers");
            RenameTable(name: "dbo.Purchase", newName: "Purchases");
            RenameTable(name: "dbo.Pizza", newName: "Pizzas");
            RenameTable(name: "dbo.CartPizza", newName: "CartPizzas");
            RenameTable(name: "dbo.PizzaPurchase", newName: "PizzaPurchases");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.PizzaPurchases", newName: "PizzaPurchase");
            RenameTable(name: "dbo.CartPizzas", newName: "CartPizza");
            RenameTable(name: "dbo.Pizzas", newName: "Pizza");
            RenameTable(name: "dbo.Purchases", newName: "Purchase");
            RenameTable(name: "dbo.ApplicationUsers", newName: "ApplicationUser");
            RenameTable(name: "dbo.Carts", newName: "Cart");
        }
    }
}
