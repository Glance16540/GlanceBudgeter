using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GlanceBudgeter.Models.CodeFirst
{
    public class Transaction
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public DateTime Created { get; set; }
        public decimal ReconciledAmount { get; set; }
        [Required]
        public bool Reconciled { get; set; }
        public string AuthorId { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public bool expense { get; set; }
      

        public virtual Expense Expense { get; set; }
        public virtual TransactionCategory Category { get; set; }
        public virtual Accounts Accounts { get; set; }
        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<TransactionAttachment> Attachment { get; set; }
    }
}