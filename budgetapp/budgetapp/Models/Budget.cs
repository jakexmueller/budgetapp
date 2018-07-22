using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace budgetapp.Models
{
    public class Budget
    {
        [Key]
        public int Id { get; set; }
        public int WeeklyWage { get; set; }
        public int Bills { get; set; }
        public int Groceries { get; set; }
        public int Transportation { get; set; }
        public int GoingOutFund { get; set; }

        
    }
}