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


        public DateTime WeekOf { get; set; }
        public int WeekTotal { get; set; }
        public int BudgetBalance { get; set; }
        public int CashTotal { get; set; }
        public double AssetTotal { get; set; }
        public double AccountTotal { get; set; }
        
    }
}