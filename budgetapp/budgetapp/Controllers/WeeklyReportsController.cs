using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using budgetapp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace budgetapp.Controllers
{
    public class WeeklyReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WeeklyReports
        public ActionResult Index()
        {
            
            return View(db.WeeklyReports.ToList());
;        }

        // GET: WeeklyReports/Details/5
        public ActionResult Details([Bind(Include = "UserID,WeeklyIncome,WeeklyBudget,Spending,Balance")] WeeklyReport weeklyReport)
        {

            //if(weeklyReport == null)
            //{
            //    db.WeeklyReports.Add(weeklyReport);
            //    db.SaveChanges();
            //}
            //string currentUserId = User.Identity.GetUserId();
            //string userId = User.Identity.GetUserId();
            //Budget budget = db.Budgets.Where(m => m.UserId == userId).FirstOrDefault();     
            ////WeeklyReport myWeeklyReport = db.WeeklyReports.Where(x => x.UserId == currentUserId).FirstOrDefault();
            //weeklyReport.UserId = userId;
            //weeklyReport.WeeklyIncome = budget.WeeklyWage;
            //weeklyReport.WeeklyBudget = budget.Bills + budget.Groceries + budget.Transportation + budget.GoingOutFund;
            //weeklyReport.Balance = weeklyReport.WeeklyBudget - weeklyReport.Spending;
            //db.SaveChanges();

            var currentUserId = User.Identity.GetUserId();
            var myWeeklyReport = db.WeeklyReports.Where(m => m.UserId == currentUserId).FirstOrDefault();

            return View(myWeeklyReport);
        }

        // GET: WeeklyReports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeeklyReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,WeeklyIncome,WeeklyBudget,Spending,Balance")] WeeklyReport weeklyReport)
        {
            if (ModelState.IsValid)
            {
                db.WeeklyReports.Add(weeklyReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(weeklyReport);
        }

        // GET: WeeklyReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeeklyReport weeklyReport = db.WeeklyReports.Find(id);
            if (weeklyReport == null)
            {
                return HttpNotFound();
            }
            return View(weeklyReport);
        }

        // POST: WeeklyReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WeeklyIncome,WeeklyBudget,Spending,Balance")] WeeklyReport weeklyReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weeklyReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(weeklyReport);
        }

        // GET: WeeklyReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeeklyReport weeklyReport = db.WeeklyReports.Find(id);
            if (weeklyReport == null)
            {
                return HttpNotFound();
            }
            return View(weeklyReport);
        }

        // POST: WeeklyReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WeeklyReport weeklyReport = db.WeeklyReports.Find(id);
            db.WeeklyReports.Remove(weeklyReport);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: WeeklyReports/AddBonus/5
        public ActionResult AddBonus()
        {
            var currentUserId = User.Identity.GetUserId();
            if (currentUserId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeeklyReport weeklyReport = db.WeeklyReports.Where(x => x.UserId == currentUserId).FirstOrDefault();
            if (weeklyReport == null)
            {
                return HttpNotFound();
            }
            return View("AddBonus");
        }

        //POST: WeeklyReports/AddBonus/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBonus([Bind(Include = "WeeklyIncome")] WeeklyReport weeklyReport)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = User.Identity.GetUserId();
                WeeklyReport myWeeklyReport = db.WeeklyReports.Where(x => x.UserId == currentUserId).FirstOrDefault();
                myWeeklyReport.WeeklyIncome += weeklyReport.WeeklyIncome;
                db.Entry(myWeeklyReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = myWeeklyReport.Id });



                //db.Entry(weeklyReport).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return View(weeklyReport);
        }

        //GET: WeeklyReports/AddPurchasedItem/5
        public ActionResult AddPurchasedItem()
        {
            var currentUserId = User.Identity.GetUserId();
            if (currentUserId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeeklyReport weeklyReport = db.WeeklyReports.Where(x => x.UserId == currentUserId).FirstOrDefault();
            if (weeklyReport == null)
            {
                return HttpNotFound();
            }
            return View("AddPurchasedItem");
        }

        //POST: WeeklyReports/AddPurchasedItem/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPurchasedItem([Bind(Include = "Spending")] WeeklyReport weeklyReport)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = User.Identity.GetUserId();
                WeeklyReport myWeeklyReport = db.WeeklyReports.Where(x=>x.UserId == currentUserId).FirstOrDefault();
                myWeeklyReport.Spending += weeklyReport.Spending;
                myWeeklyReport.Balance -= weeklyReport.Spending;
                db.Entry(myWeeklyReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new {id = myWeeklyReport.Id });
            }
            return View(weeklyReport);
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
