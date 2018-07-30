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

        public DateTime Date { get; set; }
        public int CashTotal { get; set; }
        public double AssetTotal { get; set; }
        public bool BudgetIndicator { get; set; }
    }
}