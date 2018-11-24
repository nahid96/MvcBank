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

        public DbSet<Record> Records { get; set; }
    }
}