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
    public class NaprawaController : Controller
    {
        private SBD_DBEntities db = new SBD_DBEntities();

        // GET: Naprawa
        public ActionResult Index()
        {
            var naprawa = db.Naprawa.Include(n => n.Samochod).Include(n => n.Serwis);
            return View(naprawa.ToList());
        }

        // GET: Naprawa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Naprawa naprawa = db.Naprawa.Find(id);
            if (naprawa == null)
            {
                return HttpNotFound();
            }
            return View(naprawa);
        }

        // GET: Naprawa/Create
        public ActionResult Create()
        {
            ViewBag.FK_Samochod = new SelectList(db.Samochod, "ID", "MarkaModelNumerRej");
            ViewBag.FK_Serwis = new SelectList(db.Serwis, "FK_Uzytkownik", "Nazwa");
            return View();
        }

        // POST: Naprawa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FK_Samochod,FK_Serwis,DataOddania,DataOdbioru,Opis")] Naprawa naprawa)
        {
            if (ModelState.IsValid)
            {
                db.Naprawa.Add(naprawa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Samochod = new SelectList(db.Samochod, "ID", "MarkaModelNumerRej", naprawa.FK_Samochod);
            ViewBag.FK_Serwis = new SelectList(db.Serwis, "FK_Uzytkownik", "Nazwa", naprawa.FK_Serwis);
            return View(naprawa);
        }

        // GET: Naprawa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Naprawa naprawa = db.Naprawa.Find(id);
            if (naprawa == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Samochod = new SelectList(db.Samochod, "ID", "MarkaModelNumerRej", naprawa.FK_Samochod);
            ViewBag.FK_Serwis = new SelectList(db.Serwis, "FK_Uzytkownik", "Nazwa", naprawa.FK_Serwis);
            return View(naprawa);
        }

        // POST: Naprawa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FK_Samochod,FK_Serwis,DataOddania,DataOdbioru,Opis")] Naprawa naprawa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(naprawa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Samochod = new SelectList(db.Samochod, "ID", "MarkaModelNumerRej", naprawa.FK_Samochod);
            ViewBag.FK_Serwis = new SelectList(db.Serwis, "FK_Uzytkownik", "Nazwa", naprawa.FK_Serwis);
            return View(naprawa);
        }

        // GET: Naprawa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Naprawa naprawa = db.Naprawa.Find(id);
            if (naprawa == null)
            {
                return HttpNotFound();
            }
            return View(naprawa);
        }

        // POST: Naprawa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Naprawa naprawa = db.Naprawa.Find(id);
            db.Naprawa.Remove(naprawa);
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
