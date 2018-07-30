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
    public class BudgetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Budgets
        public ActionResult Index()
        {
            return View(db.Budgets.ToList());
        }

        // GET: Budgets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budget budget = db.Budgets.Find(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            return View(budget);
        }

        // GET: Budgets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Budgets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,WeeklyWage,Bills,Groceries,Transportation,GoingOutFund")] Budget budget)
        {
            if (ModelState.IsValid)
            {
                WeeklyReport weeklyReport = new WeeklyReport();
                string currentUserId = User.Identity.GetUserId();
                budget.UserId = currentUserId;

                db.Budgets.Add(budget);
                db.WeeklyReports.Add(weeklyReport);

                //string userId = User.Identity.GetUserId();
                //Budget budget = db.Budgets.Where(m => m.UserId == userId).FirstOrDefault();
                //WeeklyReport myWeeklyReport = db.WeeklyReports.Where(x => x.UserId == currentUserId).FirstOrDefault();
                weeklyReport.UserId = currentUserId;
                weeklyReport.WeekOf = DateTime.Now.AddDays(-Convert.ToInt32(DateTime.Now.DayOfWeek));
                weeklyReport.WeeklyIncome = budget.WeeklyWage;
                weeklyReport.WeeklyBudget = budget.Bills + budget.Groceries + budget.Transportation + budget.GoingOutFund;
                weeklyReport.Balance = weeklyReport.WeeklyBudget - weeklyReport.Spending;
                db.SaveChanges();


                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(budget);
        }

        // GET: Budgets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budget budget = db.Budgets.Find(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            return View(budget);
        }

        // POST: Budgets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WeeklyWage,Bills,Groceries,Transportation,GoingOutFund")] Budget budget)
        {
            if (ModelState.IsValid)
            {
                db.Entry(budget).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(budget);
        }

        // GET: Budgets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budget budget = db.Budgets.Find(id);
            if (budget == null)
            {
                return HttpNotFound();
            }
            return View(budget);
        }

        // POST: Budgets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Budget budget = db.Budgets.Find(id);
            db.Budgets.Remove(budget);
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
