namespace MvcBank.Migrations
{
    using MvcBank.Models;
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
            
            context.Records.AddOrUpdate( x => x.Id,
            new Record() { Id =1, CardNo = 1234, Pin = 123, Balance = 5000, Count = 0},
            new Record() { Id =2, CardNo = 5678, Pin = 567, Balance = 3000, Count = 0},
            new Record() { Id =3, CardNo = 9012, Pin = 901, Balance = 2000, Count = 0}
            );
        }
    }
}
