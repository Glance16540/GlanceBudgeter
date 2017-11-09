using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GlanceBudgeter.Models.CodeFirst
{
    public class Budget
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Amount { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string OwnerId { get; set; }

        public virtual BudgetCategory Category { get; set; }
        public virtual ApplicationUser Owner { get; set; }
        public virtual Household HouseHold { get; set; }
    }
}