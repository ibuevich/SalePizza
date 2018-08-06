namespace SalePizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BeforeDependency : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Purchases", "Town");
            DropColumn("dbo.Purchases", "Street");
            DropColumn("dbo.Purchases", "House");
            DropColumn("dbo.Purchases", "Apartmen");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchases", "Apartmen", c => c.Int(nullable: false));
            AddColumn("dbo.Purchases", "House", c => c.String());
            AddColumn("dbo.Purchases", "Street", c => c.String());
            AddColumn("dbo.Purchases", "Town", c => c.String());
        }
    }
}
