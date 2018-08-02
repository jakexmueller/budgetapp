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

        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Display(Name = "Item Type")]
        public string ItemType { get; set; }

        [Display(Name = "Item Price")]
        public int ItemPrice { get; set; }


        public int DisplayNumber { get; set; }
        public string Progress { get; set; }

    }
}