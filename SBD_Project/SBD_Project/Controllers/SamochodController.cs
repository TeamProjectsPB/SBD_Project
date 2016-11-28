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
    public class SamochodController : Controller
    {
        private SBD_DBEntities db = new SBD_DBEntities();

        // GET: Samochod
        public ActionResult Index()
        {
            return View(db.Samochod.ToList());
        }

        // GET: Samochod/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samochod samochod = db.Samochod.Find(id);
            if (samochod == null)
            {
                return HttpNotFound();
            }
            return View(samochod);
        }

        // GET: Samochod/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Samochod/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NumerRej,CzyWolny,Marka,Model,Tonaz,Opis")] Samochod samochod)
        {
            if (ModelState.IsValid)
            {
                db.Samochod.Add(samochod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(samochod);
        }

        // GET: Samochod/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samochod samochod = db.Samochod.Find(id);
            if (samochod == null)
            {
                return HttpNotFound();
            }
            return View(samochod);
        }

        // POST: Samochod/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NumerRej,CzyWolny,Marka,Model,Tonaz,Opis")] Samochod samochod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(samochod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(samochod);
        }

        // GET: Samochod/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samochod samochod = db.Samochod.Find(id);
            if (samochod == null)
            {
                return HttpNotFound();
            }
            return View(samochod);
        }

        // POST: Samochod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samochod samochod = db.Samochod.Find(id);
            db.Samochod.Remove(samochod);
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
