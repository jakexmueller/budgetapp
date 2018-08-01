using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using budgetapp.Models;
using Newtonsoft.Json;

namespace budgetapp.Controllers
{
    public class SpendingHabitsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SpendingHabits
        public ActionResult Index()
        {
            //var spendingHabits = db.SpendingHabits.Include(s => s.ApplicationUser);
            //return View(spendingHabits.ToList());

            //List<SpendingHabits> dataPoints = new List<SpendingHabits>{
            //    new DataPoint(10, 22),
            //    new DataPoint(20, 36),
            //    new DataPoint(30, 42),
            //    new DataPoint(40, 51),
            //    new DataPoint(50, 46),
            //};

            //ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);


            return View(db.SpendingHabits.ToList());
        }

        // GET: SpendingHabits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpendingHabits spendingHabits = db.SpendingHabits.Find(id);
            if (spendingHabits == null)
            {
                return HttpNotFound();
            }
            return View(spendingHabits);
        }

        // GET: SpendingHabits/Create
        public ActionResult Create()
        {
            //ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email");
            return View();
        }

        // POST: SpendingHabits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,CashTotal,AssetTotal,AccountTotal")] SpendingHabits spendingHabits)
        {
            if (ModelState.IsValid)
            {
                db.SpendingHabits.Add(spendingHabits);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", spendingHabits.UserId);
            return View(spendingHabits);
        }

        // GET: SpendingHabits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpendingHabits spendingHabits = db.SpendingHabits.Find(id);
            if (spendingHabits == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", spendingHabits.UserId);
            return View(spendingHabits);
        }

        // POST: SpendingHabits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,CashTotal,AssetTotal,AccountTotal")] SpendingHabits spendingHabits)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spendingHabits).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", spendingHabits.UserId);
            return View(spendingHabits);
        }

        // GET: SpendingHabits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpendingHabits spendingHabits = db.SpendingHabits.Find(id);
            if (spendingHabits == null)
            {
                return HttpNotFound();
            }
            return View(spendingHabits);
        }

        // POST: SpendingHabits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpendingHabits spendingHabits = db.SpendingHabits.Find(id);
            db.SpendingHabits.Remove(spendingHabits);
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
