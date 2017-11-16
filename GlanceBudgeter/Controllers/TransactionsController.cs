using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GlanceBudgeter.Models;
using GlanceBudgeter.Models.CodeFirst;
using Microsoft.AspNet.Identity;

namespace GlanceBudgeter.Controllers
{
    [Authorize]
    public class TransactionsController : Universal
    {
       

        // GET: Transactions
        public ActionResult Index()
        {
            var transactions = db.transaction.Include(t => t.Author).Include(t => t.Category);
            return View(transactions.ToList());
        }

        // GET: Transactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.transaction.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            Transaction transaction = new Transaction();

            var user = db.Users.Find(User.Identity.GetUserId());
            ViewBag.AuthorId = new SelectList(db.Users.Where(u=>u.Household.Id == user.HouseholdId), "Id", "FirstName");
            ViewBag.CategoryId = new SelectList(db.transactioncategory, "Id", "Name");
            ViewBag.AccountsId = new SelectList(db.Account.Where(a => a.HouseholdId == user.HouseholdId), "Id", "Name");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Amount,Created,ReconciledAmount,Reconciled,AuthorId,CategoryId,AccountsId")] Transaction transaction)
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            Accounts accounts = db.Account.Find(transaction.AccountsId);

            ViewBag.CategoryId = new SelectList(db.transactioncategory, "Id", "Name");
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName");
            ViewBag.AccountsId = new SelectList(db.Account, "Id", "Name",transaction.AccountsId);
            if (ModelState.IsValid)
            {
              
                //  var accountid = db.Account.Find(account.Id == user.)
                //transaction.AccountsId = accoun

                
                //if (transaction.CategoryId == 2)
                //{
                //    decimal transAmt = transaction.Amount * -1;
                //    accounts.Balance = accounts.Balance + transAmt;
                //}
                //if (transaction.CategoryId == 1)
                //{
                //    accounts.Balance = accounts.Balance + transaction.Amount;
                //}


                //db.Entry(accounts).State = EntityState.Modified;

                transaction.Reconciled = false;
                transaction.HouseholdId = user.HouseholdId.Value;
                
                transaction.Created = DateTime.UtcNow;
                db.transaction.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.transaction.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName", transaction.AuthorId);
            ViewBag.CategoryId = new SelectList(db.transactioncategory, "Id", "Name", transaction.CategoryId);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Amount,Created,ReconciledAmount,Reconciled,AuthorId,CategoryId")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName", transaction.AuthorId);
            ViewBag.CategoryId = new SelectList(db.transactioncategory, "Id", "Name", transaction.CategoryId);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.transaction.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction transaction = db.transaction.Find(id);
            db.transaction.Remove(transaction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
