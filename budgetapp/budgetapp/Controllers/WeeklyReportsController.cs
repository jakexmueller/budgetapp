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

namespace budgetapp.Controllers
{
    public class WeeklyReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WeeklyReports
        public ActionResult Index()
        {
            //string currentUserId = User.Identity.GetUserId();
            //Budget budget = db.Budgets.Where(m => m.UserId == currentUserId).FirstOrDefault();

            //int weeklyWage = budget.WeeklyWage;
            //int weeklyBudget = (budget.Bills)+(budget.Groceries)+(budget.Transportation)+(budget.GoingOutFund);
            //int weeklySpending = 0;
            //int weeklyBalance = weeklyBudget - weeklySpending;
            ////IEnumerable<WeeklyReport> weeklyReport = null;
            ////List<WeeklyReport> weeklyReport = new List<WeeklyReport>();
            //WeeklyReport weeklyReport = new WeeklyReport();
            //weeklyReport.WeeklyIncome  = weeklyWage;
            //weeklyReport.WeeklyBudget = weeklyBudget;
            //weeklyReport.Spending = weeklySpending;
            //weeklyReport.Balance = weeklyBalance;
            //return View(weeklyReport.ToList());
            return View(db.WeeklyReports.ToList());
;        }

        // GET: WeeklyReports/Details/5
        public ActionResult Details(/*int? id*/)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //WeeklyReport customerWeeklyReport = db.WeeklyReports.Find(id);
            //if (customerWeeklyReport == null)
            //{
            //    return HttpNotFound();
            //}

            string currentUserId = User.Identity.GetUserId();
            Budget budget = db.Budgets.Where(m => m.UserId == currentUserId).FirstOrDefault();

            int weeklyWage = budget.WeeklyWage;
            int weeklyBudget = (budget.Bills) + (budget.Groceries) + (budget.Transportation) + (budget.GoingOutFund);
            int weeklySpending = 0;
            int weeklyBalance = weeklyBudget - weeklySpending;
            //IEnumerable<WeeklyReport> weeklyReport = null;
            //List<WeeklyReport> weeklyReport = new List<WeeklyReport>();
            WeeklyReport weeklyReport = new WeeklyReport();
            weeklyReport.WeeklyIncome = weeklyWage;
            weeklyReport.WeeklyBudget = weeklyBudget;
            weeklyReport.Spending = weeklySpending;
            weeklyReport.Balance = weeklyBalance;
            return View(weeklyReport);

            //return View(weeklyReport);
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
        public ActionResult Create([Bind(Include = "WeeklyIncome,WeeklyBudget,Spending,Balance")] WeeklyReport weeklyReport)
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
