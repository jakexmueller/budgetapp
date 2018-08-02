using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace budgetapp.Models
{
    public class Budget
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Weekly Wage")]
        public int WeeklyWage { get; set; }

        public int Bills { get; set; }
        public int Groceries { get; set; }
        public int Transportation { get; set; }

        [Display(Name = "Social Fund")]
        public int GoingOutFund { get; set; }

        
    }
}