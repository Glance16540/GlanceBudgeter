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
    public class AccountsController : Universal
    {
       

        // GET: Accounts
        public ActionResult Index()
        {
            var accounts = db.Account.Include(a => a.AccountType).Include(a => a.Owner);
            return View(accounts.ToList());
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accounts accounts = db.Account.Find(id);
            if (accounts == null)
            {
                return HttpNotFound();
            }
            return View(accounts);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            ViewBag.AccountTypeId = new SelectList(db.Accounttype, "Id", "Name");
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "FirstName");
            ViewBag.AccountType = new SelectList(db.Accounttype, "Id", "Name");
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Opened,Closed,AccountNumber,OwnerId,AccountTypeId")] Accounts accounts)
        {
            ViewBag.AccountTypeId = new SelectList(db.Accounttype, "Id", "Name", accounts.AccountTypeId);
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "FirstName", accounts.OwnerId);
            ViewBag.AccountType = new SelectList(db.Accounttype, "Id", "Name");
        
            if (ModelState.IsValid)
            { 
               var user = User.Identity.GetUserId();
                accounts.OwnerId = user;
                db.Account.Add(accounts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accounts);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accounts accounts = db.Account.Find(id);
            if (accounts == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountTypeId = new SelectList(db.Accounttype, "Id", "Name", accounts.AccountTypeId);
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "FirstName", accounts.OwnerId);
            return View(accounts);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Opened,Closed,AccountNumber,OwnerId,AccountTypeId")] Accounts accounts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accounts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountTypeId = new SelectList(db.Accounttype, "Id", "Name", accounts.AccountTypeId);
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "FirstName", accounts.OwnerId);
            return View(accounts);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accounts accounts = db.Account.Find(id);
            if (accounts == null)
            {
                return HttpNotFound();
            }
            return View(accounts);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accounts accounts = db.Account.Find(id);
            db.Account.Remove(accounts);
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
