namespace SalePizza.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddPizzaMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pizzas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Diameter = c.Double(nullable: false),
                        Composition = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        PizzaId = c.Int(nullable: false),
                        BuerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buers", t => t.BuerId, cascadeDelete: true)
                .ForeignKey("dbo.Pizzas", t => t.PizzaId, cascadeDelete: true)
                .Index(t => t.PizzaId)
                .Index(t => t.BuerId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "PizzaId", "dbo.Pizzas");
            DropForeignKey("dbo.Purchases", "BuerId", "dbo.Buers");
            DropIndex("dbo.Purchases", new[] { "BuerId" });
            DropIndex("dbo.Purchases", new[] { "PizzaId" });
            DropTable("dbo.Purchases");
            DropTable("dbo.Pizzas");
            DropTable("dbo.Buers");
        }
    }
}
