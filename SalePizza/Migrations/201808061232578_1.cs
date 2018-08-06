namespace SalePizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "Town", c => c.String());
            AddColumn("dbo.Purchases", "Street", c => c.String());
            AddColumn("dbo.Purchases", "House", c => c.String());
            AddColumn("dbo.Purchases", "Apartmen", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "Apartmen");
            DropColumn("dbo.Purchases", "House");
            DropColumn("dbo.Purchases", "Street");
            DropColumn("dbo.Purchases", "Town");
        }
    }
}
