using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SBD_Project.Models;

namespace SBD_Project.Controllers
{
    public class CennikController : Controller
    {
        private SBD_DBEntities db = new SBD_DBEntities();

        // GET: Cennik
        public ActionResult Index()
        {
            return View(db.Cennik.ToList());
        }

        // GET: Cennik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cennik cennik = db.Cennik.Find(id);
            if (cennik == null)
            {
                return HttpNotFound();
            }
            return View(cennik);
        }

        // GET: Cennik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cennik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MinWaga,MaxWaga,Cena")] Cennik cennik)
        {
            if (ModelState.IsValid)
            {
                db.Cennik.Add(cennik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cennik);
        }

        // GET: Cennik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cennik cennik = db.Cennik.Find(id);
            if (cennik == null)
            {
                return HttpNotFound();
            }
            return View(cennik);
        }

        // POST: Cennik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MinWaga,MaxWaga,Cena")] Cennik cennik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cennik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cennik);
        }

        // GET: Cennik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cennik cennik = db.Cennik.Find(id);
            if (cennik == null)
            {
                return HttpNotFound();
            }
            return View(cennik);
        }

        // POST: Cennik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cennik cennik = db.Cennik.Find(id);
            db.Cennik.Remove(cennik);
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
