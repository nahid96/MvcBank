using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBank.Models
{
    public class Record
    {
        public int Id { get; set; }

        [Display(Name = "Card No.")]
        public int CardNo { get; set; }

        public int Pin { get; set; }

        public int Balance { get; set; }

        public int Count { get; set; }      
    }
}