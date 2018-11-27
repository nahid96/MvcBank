using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBank.Models
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "Card Number")]
        public int CardNumber { get; set; }

        public int Pin { get; set; }

        public int Balance { get; set; }
    }
}