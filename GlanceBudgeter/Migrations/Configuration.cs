namespace GlanceBudgeter.Migrations
{
    using GlanceBudgeter.Models.CodeFirst;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GlanceBudgeter.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GlanceBudgeter.Models.ApplicationDbContext context)
        {
            if (!context.Account.Any(p => p.Name == "Checking"))
            {
                var accounttype = new AccountType();
                accounttype.Name = "Checking";
                context.Accounttype.Add(accounttype);
            }
            if (!context.Account.Any(p => p.Name == "Savings"))
            {
                var accounttype = new AccountType();
                accounttype.Name = "Savings";
                context.Accounttype.Add(accounttype);
            }
        }
    }
}
