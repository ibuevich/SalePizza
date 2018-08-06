namespace SalePizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Disable_Validations_For_Purchase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Purchases", "Town", c => c.String());
            AlterColumn("dbo.Purchases", "Street", c => c.String());
            AlterColumn("dbo.Purchases", "House", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Purchases", "House", c => c.String(nullable: false));
            AlterColumn("dbo.Purchases", "Street", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Purchases", "Town", c => c.String(nullable: false));
        }
    }
}
