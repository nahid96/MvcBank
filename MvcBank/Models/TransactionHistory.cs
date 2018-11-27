using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBank.Models
{
    public class TransactionHistory
    {
        public int Id { get; set; }
        public int TransactionCount { get; set; }
        public int TransactionAmount { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}