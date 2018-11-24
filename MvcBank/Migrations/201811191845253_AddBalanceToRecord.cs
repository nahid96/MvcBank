namespace MvcBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBalanceToRecord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Records", "Balance", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Records", "Balance");
        }
    }
}
