namespace SalePizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modify_models_to_correctly_Aut : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Buyers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Buyers", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
