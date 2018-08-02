using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace budgetapp.Models
{
    public class SpendingHabits
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Week of:")]
        public DateTime WeekOf { get; set; }

        [Display(Name = "Week Total")]
        public int WeekTotal { get; set; }

        [Display(Name = "Budget Balance")]
        public int BudgetBalance { get; set; }

        [Display(Name = "Total in Cash")]
        public int CashTotal { get; set; }

        [Display(Name = "Total in Assets")]
        public double AssetTotal { get; set; }

        [Display(Name = "Accumulative Total")]
        public double AccountTotal { get; set; }
        
    }
}