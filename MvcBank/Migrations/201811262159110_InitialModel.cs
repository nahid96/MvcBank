namespace MvcBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransactionHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionCount = c.Int(nullable: false),
                        TransactionAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardNumber = c.Int(nullable: false),
                        Pin = c.Int(nullable: false),
                        Balance = c.Int(nullable: false),
                        TransactionHistoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TransactionHistories", t => t.TransactionHistoryId, cascadeDelete: true)
                .Index(t => t.TransactionHistoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "TransactionHistoryId", "dbo.TransactionHistories");
            DropIndex("dbo.Users", new[] { "TransactionHistoryId" });
            DropTable("dbo.Users");
            DropTable("dbo.TransactionHistories");
        }
    }
}
