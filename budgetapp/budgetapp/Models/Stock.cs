using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace budgetapp.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }

        public int CurrentPrice { get; set; }
        public int OneMonthAgoPrice { get; set; }
        public int TwoMonthsAgoPrice { get; set; }
        public int ThreeMonthsAgoPrice { get; set; }
        public int FourMonthsAgoPrice { get; set; }
        public int FiveMonthsAgoPrice { get; set; }
        public int SixMonthsAgoPrice { get; set; }
    }
}