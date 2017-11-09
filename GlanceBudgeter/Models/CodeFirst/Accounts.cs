using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GlanceBudgeter.Models.CodeFirst
{
    public class Accounts
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Balance { get; set; }
        public DateTime Opened { get; set; }
        public DateTime? Closed { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public string OwnerId { get; set; }
        [Required]
        public int AccountTypeId { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual Household HouseHold { get; set; }
        public virtual ApplicationUser Owner { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }


    }
}