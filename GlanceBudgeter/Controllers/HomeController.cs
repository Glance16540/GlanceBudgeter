using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GlanceBudgeter.Models;
using System.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace GlanceBudgeter.Controllers
{
    [Authorize]
    public class HomeController : Universal
    {
        public ActionResult Index()
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            var house = db.household.Find(user.HouseholdId);
            return View(house);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();


        }

        public ActionResult CreateJoinHouseHold()
        {
            // Implementation for creating and joining a house hold
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var body = "<p>Email From: <bold>{0}</bold>({1})</p><p>Message: </p><p>{2}</p>";
                    var from = "MyPortfolio<antonio@raynor.com>";
                    model.Body = "This is a message from your portfolio site. The name and the email of the contacting person is above.";
                    var email = new MailMessage(from, ConfigurationManager.AppSettings["emailto"])
                    {
                        Subject = "Portfolio Contact Email",
                        Body = string.Format(body, model.FromName, model.FromEmail, model.Body),
                        IsBodyHtml = true
                    };
                    var svc = new PersonalEmail();
                    await svc.SendAsync(email);
                    return RedirectToAction("Sent");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.FromResult(0);
                }
            }
            return View(model);
        }




    }

}