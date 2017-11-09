using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlanceBudgeter.Models.CodeFirst
{
    public class Household
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string OwnerId { get; set; }
        public string Password { get; set; }

        public virtual ICollection<ApplicationUser> Members { get; set; }

    }
}