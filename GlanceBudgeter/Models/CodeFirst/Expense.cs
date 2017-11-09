using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GlanceBudgeter.Models.CodeFirst
{
    public class Expense
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string OwnerId { get; set; }
        public string Description { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public virtual ExpenseCategory Category { get; set; }
        public virtual ApplicationUser Owner { get; set; }

    }
}