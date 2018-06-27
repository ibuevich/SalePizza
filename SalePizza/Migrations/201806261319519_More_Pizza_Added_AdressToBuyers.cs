namespace SalePizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class More_Pizza_Added_AdressToBuyers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyers", "Adress", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Buyers", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Buyers", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Buyers", "Adress");
        }
    }
}
