using MvcBank.Models;

namespace MvcBank.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcBank.Models.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcBank.Models.MyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Users.AddOrUpdate(x => x.Id,
                new User() { Id = 1, CardNumber = 1234, Pin = 123, Balance = 5000 },
                new User() { Id = 2, CardNumber = 5678, Pin = 567, Balance = 3000 },
                new User() { Id = 3, CardNumber = 9012, Pin = 901, Balance = 2000 }
            );

            context.TransactionHistories.AddOrUpdate(x => x.Id,
                new TransactionHistory() { Id = 1, TransactionCount = 0, TransactionAmount = 0, UserId = 1 },
                new TransactionHistory() { Id = 2, TransactionCount = 0, TransactionAmount = 0, UserId = 2 },
                new TransactionHistory() { Id = 3, TransactionCount = 0, TransactionAmount = 0, UserId = 3 }
            );
        }
    }
}
