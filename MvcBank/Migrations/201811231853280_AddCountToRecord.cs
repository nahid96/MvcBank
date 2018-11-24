namespace MvcBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountToRecord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Records", "Count", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Records", "Count");
        }
    }
}
