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
using System.Threading.Tasks;
using GlanceBudgeter.Models.Helpers;

namespace GlanceBudgeter.Controllers
{
    [Authorize]
    public class HouseholdsController : Universal
    {



        // GET: HouseHolds
        public ActionResult Index()
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            if (user.HouseholdId != null)
            {
                var houseHold = db.household.Find(user.HouseholdId);
                return View(houseHold);
            }
            return RedirectToAction("CreateJoinHouseHold", "Home");
        }


        // GET: Households/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.household.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // GET: Households/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Households/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,OwnerId,")] Household household)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Find(User.Identity.GetUserId());
                household.OwnerId = User.Identity.GetUserId();
                user.HouseholdId = household.Id;
                household.Created = DateTime.Now;

                db.household.Add(household);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(household);
        }

        // GET: Households/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.household.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // GET: HouseHolds/OneHouseWarning
        public ActionResult OneHouseWarning()
        {
            return View();
        }

        // POST: HouseHolds/SurenderHouseId
        public async Task<ActionResult> SurrenderHouseId(int? id)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Find(User.Identity.GetUserId());
                Household houseHold = db.household.Find(id);
                user.HouseholdId = null;
                //if (houseHold.Members.Count == 0)
                //{
                //    db.HouseHold.Remove(houseHold);
                //}
                db.SaveChanges();

                await HttpContext.RefreshAuthentication(db.Users.Find(User.Identity.GetUserId()));
                return RedirectToAction("CreateJoinHouseHold", "Home");
            }
            return View();
        }



        // POST: Households/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Created,Updated,OwnerId,Password")] Household household)
        {
            if (ModelState.IsValid)
            {
                db.Entry(household).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(household);
        }

        // GET: Households/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.household.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // POST: Households/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            var user = db.Users.Find(User.Identity.GetUserId());
            Household household = db.household.Find(id);
            user.HouseholdId = null;
            
            db.household.Remove(household);
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
