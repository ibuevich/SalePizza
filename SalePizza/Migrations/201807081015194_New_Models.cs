namespace SalePizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_Models : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.Int(nullable: false),
                        AverageCost = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(),
                        DefaultAddress = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        CartId = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        Price = c.Double(nullable: false),
                        ApplicationUserId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Pizza",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Diameter = c.Double(),
                        Composition = c.String(maxLength: 150),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.RoleId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.PizzaPurchase",
                c => new
                    {
                        Pizza_Id = c.Int(nullable: false),
                        Purchase_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pizza_Id, t.Purchase_Id })
                .ForeignKey("dbo.Pizza", t => t.Pizza_Id, cascadeDelete: true)
                .ForeignKey("dbo.Purchase", t => t.Purchase_Id, cascadeDelete: true)
                .Index(t => t.Pizza_Id)
                .Index(t => t.Purchase_Id);
            
            CreateTable(
                "dbo.CartPizza",
                c => new
                    {
                        Cart_Id = c.Int(nullable: false),
                        Pizza_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Cart_Id, t.Pizza_Id })
                .ForeignKey("dbo.Cart", t => t.Cart_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pizza", t => t.Pizza_Id, cascadeDelete: true)
                .Index(t => t.Cart_Id)
                .Index(t => t.Pizza_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CartPizza", "Pizza_Id", "dbo.Pizza");
            DropForeignKey("dbo.CartPizza", "Cart_Id", "dbo.Cart");
            DropForeignKey("dbo.Cart", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.AspNetUserRoles", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.PizzaPurchase", "Purchase_Id", "dbo.Purchase");
            DropForeignKey("dbo.PizzaPurchase", "Pizza_Id", "dbo.Pizza");
            DropForeignKey("dbo.Purchase", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.AspNetUserLogins", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.AspNetUserClaims", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.CartPizza", new[] { "Pizza_Id" });
            DropIndex("dbo.CartPizza", new[] { "Cart_Id" });
            DropIndex("dbo.PizzaPurchase", new[] { "Purchase_Id" });
            DropIndex("dbo.PizzaPurchase", new[] { "Pizza_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.Purchase", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Cart", new[] { "ApplicationUser_Id" });
            DropTable("dbo.CartPizza");
            DropTable("dbo.PizzaPurchase");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Pizza");
            DropTable("dbo.Purchase");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Cart");
        }
    }
}
