using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlanceBudgeter.Models.CodeFirst
{
    public class ExpenseCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HouseHoldId { get; set; }

        public virtual Household HouseHold { get; set; }
    }
}