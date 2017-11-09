using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GlanceBudgeter.Models.CodeFirst
{
    public class Income
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string OwnerId { get; set; }
        [Required]
        public int IncomeTypeId { get; set; }
        [Required]
        public string Frequency { get; set; }

        public virtual ApplicationUser Owner { get; set; }


    }
}