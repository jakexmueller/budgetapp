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

        public string Symbol { get; set; }
        public double CurrentPrice { get; set; }
        public double OneMonthAgoPrice { get; set; }
        public double TwoMonthsAgoPrice { get; set; }
        public double ThreeMonthsAgoPrice { get; set; }
        public double FourMonthsAgoPrice { get; set; }
        public double FiveMonthsAgoPrice { get; set; }
        public double SixMonthsAgoPrice { get; set; }
    }
}