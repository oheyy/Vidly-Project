namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvailabilityToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Availability", c => c.Byte(nullable: false));

            Sql("UPDATE Movies SET Availability = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Availability");
        }
    }
}
