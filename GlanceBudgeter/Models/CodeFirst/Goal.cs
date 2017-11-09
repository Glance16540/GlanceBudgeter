using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GlanceBudgeter.Models.CodeFirst
{
    public class Goal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public DateTime? Update { get; set; }
        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }
    }
}