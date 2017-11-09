using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using GlanceBudgeter.Models.CodeFirst;

namespace GlanceBudgeter.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePic { get; set; }
        public string TimeZone { get; set; }
     
    

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }


        public ApplicationUser()
        {
            Transactions = new HashSet<Transaction>();
            TransactionAttachments = new HashSet<TransactionAttachment>();
            Account = new HashSet<Accounts>();
            Notifications = new HashSet<Notification>();
            budget = new HashSet<Budget>();
        }


        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<TransactionAttachment> TransactionAttachments { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Accounts>Account { get; set; }
        public virtual ICollection<Budget>budget { get; set; }
  


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {

            return new ApplicationDbContext();
        }

        public DbSet<Accounts>Account {get;set;}
        public DbSet<AccountType> Accounttype {get;set;}
        public DbSet<Budget>budget {get;set;}
        public DbSet<BudgetCategory>budgetcategory {get;set;}
        public DbSet<Expense>expense {get;set;}
        public DbSet<ExpenseCategory> expensecategory {get;set;}
  
        public DbSet<Goal>goal {get;set;}
        public DbSet<Household> household { get; set; }
        public DbSet<Income> income { get; set; }
        public DbSet<Notification> notification { get; set; }
        public DbSet<Transaction> transaction { get; set; }
        public DbSet<TransactionAttachment> transactionattachment { get; set; }
        public DbSet<TransactionCategory> transactioncategory { get; set; }
    }
}