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



            if (!context.budgetcategory.Any(b => b.Name == "Food"))
            {
                var category = new BudgetCategory();
                category.Name = "Food";
                context.budgetcategory.Add(category);
            }

            if (!context.budgetcategory.Any(b => b.Name == "Gas"))
            {
                var category = new BudgetCategory();
                category.Name = "Gas";
                context.budgetcategory.Add(category);
            }

            if (!context.budgetcategory.Any(b => b.Name == "School"))
            {
                var category = new BudgetCategory();
                category.Name = "School";
                context.budgetcategory.Add(category);
            }

            if (!context.budgetcategory.Any(b => b.Name == "Living"))
            {
                var category = new BudgetCategory();
                category.Name = "Living";
                context.budgetcategory.Add(category);
            }

            if (!context.budgetcategory.Any(b => b.Name == "Other"))
            {
                var category = new BudgetCategory();
                category.Name = "Other";
                context.budgetcategory.Add(category);
            }

            if (!context.transactioncategory.Any(t => t.Name == "Expense"))
            {
                var trans = new TransactionCategory();
                trans.Name = "Expense";
                context.transactioncategory.Add(trans);
            }

            if (!context.transactioncategory.Any(t => t.Name == "Income"))
            {
                var trans = new TransactionCategory();
                trans.Name = "Income";
                context.transactioncategory.Add(trans);
            }









        }
    }
}
