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

        public DateTime WeekOf { get; set; }
        public int WeeklyIncome { get; set; }
        public int WeeklyBudget { get; set; }
        public int Spending { get; set; }
        public int Balance { get; set; }

    }
}