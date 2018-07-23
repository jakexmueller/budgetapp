using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace budgetapp.Models
{
    public class WishList
    {
        [Key]
        public int ItemId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
    }
}