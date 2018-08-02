using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace budgetapp.Models
{
    public class WeeklyReport
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Week of:")]
        public DateTime WeekOf { get; set; }

        [Display(Name = "Weekly Income")]
        public int WeeklyIncome { get; set; }

        [Display(Name = "Weekly Budget")]
        public int WeeklyBudget { get; set; }

        public int Spending { get; set; }
        public int Balance { get; set; }

    }
}