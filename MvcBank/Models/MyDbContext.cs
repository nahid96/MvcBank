using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcBank.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }
    }
}