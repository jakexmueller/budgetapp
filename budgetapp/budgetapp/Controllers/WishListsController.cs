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
    public class WishListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WishLists
        public ActionResult Index()
        {

            string currentUserId = User.Identity.GetUserId();
            var weeklyReport = db.WeeklyReports.Where(w => w.UserId == currentUserId).FirstOrDefault();
            Console.WriteLine(db.WishLists);
            //var currentItem = db.WishLists.Where(w=>w.UserId == currentUserId).Where(w => w.DisplayNumber == 1).FirstOrDefault();
            var wishListItems = db.WishLists.Where(w => w.UserId == currentUserId).ToList();


            if (wishListItems.Count > 0)
            {
                var currentItem = wishListItems.Where(w => w.DisplayNumber == 1).FirstOrDefault();
                var savingsAccount = db.SpendingHabits.Where(w => w.UserId == currentUserId).FirstOrDefault();
                if (currentItem.ItemPrice > .05 * savingsAccount.CashTotal)
                {
                    currentItem.Progress = ((Math.Round((currentItem.ItemPrice / ((weeklyReport.WeeklyIncome - weeklyReport.WeeklyBudget) * .05)))).ToString()) + " weeks";
                }
                else
                {
                    currentItem.Progress = "Purchasable";
                }

                
                //db.SaveChanges();

            }
            wishListItems.OrderBy(x => x.DisplayNumber).ToList();
            return View(wishListItems);

            //var wishLists = db.WishLists.Include(w => w.ApplicationUser).OrderBy(x => x.DisplayNumber).ToList();
            //return View(wishLists);
        }

        // GET: WishLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WishList wishList = db.WishLists.Find(id);
            if (wishList == null)
            {
                return HttpNotFound();
            }
            return View(wishList);
        }

        // GET: WishLists/Create
        public ActionResult Create()
        {
            //ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: WishLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,UserId,ItemName,ItemPrice,Progress")] WishList wishList)
        {
            if (ModelState.IsValid)
            {
                db.WishLists.Add(wishList);
                //if no records, assign 1, if there are, increment by 1
                //var x = query that finds highest display number and increment by 1
                
                if (db.WishLists.Count() == 0)
                {
                    wishList.DisplayNumber = 1;
                }
                else
                {
                    int maxDisplayNumber = db.WishLists.Max(p => p.DisplayNumber);

                    wishList.DisplayNumber = maxDisplayNumber + 1;
                }
                var currentUserId = User.Identity.GetUserId();
                wishList.UserId = currentUserId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            //ViewBag.UserId = new SelectList(db.Users, "Id", "Email", wishList.UserId);
            return View(wishList);
        }

        // GET: WishLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WishList wishList = db.WishLists.Find(id);
            if (wishList == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", wishList.UserId);
            return View(wishList);
        }

        // POST: WishLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,UserId,ItemName,ItemPrice")] WishList wishList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wishList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", wishList.UserId);
            return View(wishList);
        }

        // GET: WishLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WishList wishList = db.WishLists.Find(id);
            if (wishList == null)
            {
                return HttpNotFound();
            }
            return View(wishList);
        }

        // POST: WishLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WishList wishList = db.WishLists.Find(id);
            db.WishLists.Remove(wishList);
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

        //GET: WishLists/MoveToFront/5
        public ActionResult MoveToFront([Bind(Include = "DisplayNumber")]int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WishList wishList = db.WishLists.Find(id);
            if (wishList == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", wishList.UserId);


            WishList newItemToSave = db.WishLists.Find(id);
            var currentDisplayNumber = newItemToSave.DisplayNumber;
            var oldSavingsItem = db.WishLists.Where(p => p.DisplayNumber == 1).FirstOrDefault();
            newItemToSave.DisplayNumber = 1;
            oldSavingsItem.DisplayNumber = currentDisplayNumber;
            db.SaveChanges();

            return RedirectToAction("Index");

            //return View(wishList);
        }

        ////POST: WishLists/MoveToFront/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult MoveToFront( int id)
        //{
            
        //}
    }
}
