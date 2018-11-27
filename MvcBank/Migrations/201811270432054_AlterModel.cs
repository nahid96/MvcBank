namespace MvcBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "TransactionHistoryId", "dbo.TransactionHistories");
            DropIndex("dbo.Users", new[] { "TransactionHistoryId" });
            AddColumn("dbo.TransactionHistories", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.TransactionHistories", "UserId");
            AddForeignKey("dbo.TransactionHistories", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.Users", "TransactionHistoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "TransactionHistoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.TransactionHistories", "UserId", "dbo.Users");
            DropIndex("dbo.TransactionHistories", new[] { "UserId" });
            DropColumn("dbo.TransactionHistories", "UserId");
            CreateIndex("dbo.Users", "TransactionHistoryId");
            AddForeignKey("dbo.Users", "TransactionHistoryId", "dbo.TransactionHistories", "Id", cascadeDelete: true);
        }
    }
}
