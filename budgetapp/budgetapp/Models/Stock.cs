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

        [Display(Name = "Current Price")]
        public double CurrentPrice { get; set; }

        [Display(Name = "One Month Ago Price")]
        public double OneMonthAgoPrice { get; set; }

        [Display(Name = "Two Months Ago Price")]
        public double TwoMonthsAgoPrice { get; set; }

        [Display(Name = "Three Months Ago Price")]
        public double ThreeMonthsAgoPrice { get; set; }

        [Display(Name = "Four Months Ago Price")]
        public double FourMonthsAgoPrice { get; set; }

        [Display(Name = "Five Months Ago Price")]
        public double FiveMonthsAgoPrice { get; set; }

        [Display(Name = "Six Months Ago Price")]
        public double SixMonthsAgoPrice { get; set; }
    }
}