using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newvics.Models;

namespace Newvics.Controllers
{
    public class RanksController : Controller
    {
        private Newvics_dbEntities db = new Newvics_dbEntities();

        // GET: Ranks
        public ActionResult Index()
        {
            var rank = db.Rank.OrderByDescending(t => t.Date).FirstOrDefault();
            var date = rank.Date;
            var rankList = db.Rank.Include(r => r.Team).Where(r => r.Date == date && r.Rank1 < 4);
            string ss = date.ToString();
            string[] sArray = ss.Split(' ');
            ViewData["rankList"] = rankList;
            ViewData["date"] = sArray[0];
            return View();
        }

        // GET: Ranks/Details/5
        public ActionResult Details()
        {
            var rank = db.Rank.OrderByDescending(t => t.Date).FirstOrDefault();
            var date = rank.Date;
            var rankList = db.Rank.Include(r => r.Team).Where(r => r.Date == date && r.Rank1 < 4);
            string ss = date.ToString();
            string[] sArray = ss.Split(' ');
            ViewData["rankList"] = rankList;
            ViewData["date"] = sArray[0];
            return View();
        }

        // GET: Ranks/Create
        public ActionResult Create()
        {
            ViewBag.Teamid = new SelectList(db.Team, "Id", "Name");
            return View();
        }

        // POST: Ranks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Teamid,Rank1,Date")] Rank rank)
        {
            if (ModelState.IsValid)
            {
                db.Rank.Add(rank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Teamid = new SelectList(db.Team, "Id", "Name", rank.Teamid);
            return View(rank);
        }

        // GET: Ranks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rank rank = db.Rank.Find(id);
            if (rank == null)
            {
                return HttpNotFound();
            }
            ViewBag.Teamid = new SelectList(db.Team, "Id", "Name", rank.Teamid);
            return View(rank);
        }

        // POST: Ranks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Teamid,Rank1,Date")] Rank rank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Teamid = new SelectList(db.Team, "Id", "Name", rank.Teamid);
            return View(rank);
        }

        // GET: Ranks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rank rank = db.Rank.Find(id);
            if (rank == null)
            {
                return HttpNotFound();
            }
            return View(rank);
        }

        // POST: Ranks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rank rank = db.Rank.Find(id);
            db.Rank.Remove(rank);
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
