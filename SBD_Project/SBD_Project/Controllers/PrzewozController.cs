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
    public class PrzewozController : Controller
    {
        private SBD_DBEntities db = new SBD_DBEntities();

        // GET: Przewoz
        public ActionResult Index()
        {
            var przewoz = db.Przewoz.Include(p => p.Kierowca).Include(p => p.Samochod);
            return View(przewoz.ToList());
        }

        public ActionResult DriversIndex(int id)
        {

            var przewoz = db.Przewoz.Include(p => p.Kierowca).Include(p => p.Samochod).Include(p => p.Paczka);
            return View();
        }
        // GET: Przewoz/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przewoz przewoz = db.Przewoz.Find(id);
            if (przewoz == null)
            {
                return HttpNotFound();
            }
            return View(przewoz);
        }

        // GET: Przewoz/Create
        public ActionResult Create()
        {
            ViewBag.FK_Kierowca = new SelectList(db.Kierowca, "FK_Uzytkownik", "Nazwisko");
            ViewBag.FK_Samochod = new SelectList(db.Samochod, "ID", "NumerRej");
            return View();
        }

        // POST: Przewoz/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FK_Samochod,FK_Kierowca,DataPrzewozu")] Przewoz przewoz)
        {
            if (ModelState.IsValid)
            {
                db.Przewoz.Add(przewoz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Kierowca = new SelectList(db.Kierowca, "FK_Uzytkownik", "Nazwisko", przewoz.FK_Kierowca);
            ViewBag.FK_Samochod = new SelectList(db.Samochod, "ID", "NumerRej", przewoz.FK_Samochod);
            return View(przewoz);
        }

        // GET: Przewoz/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przewoz przewoz = db.Przewoz.Find(id);
            if (przewoz == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Kierowca = new SelectList(db.Kierowca, "FK_Uzytkownik", "Nazwisko", przewoz.FK_Kierowca);
            ViewBag.FK_Samochod = new SelectList(db.Samochod, "ID", "NumerRej", przewoz.FK_Samochod);
            return View(przewoz);
        }

        // POST: Przewoz/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FK_Samochod,FK_Kierowca,DataPrzewozu")] Przewoz przewoz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(przewoz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Kierowca = new SelectList(db.Kierowca, "FK_Uzytkownik", "Nazwisko", przewoz.FK_Kierowca);
            ViewBag.FK_Samochod = new SelectList(db.Samochod, "ID", "NumerRej", przewoz.FK_Samochod);
            return View(przewoz);
        }

        // GET: Przewoz/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przewoz przewoz = db.Przewoz.Find(id);
            if (przewoz == null)
            {
                return HttpNotFound();
            }
            return View(przewoz);
        }

        // POST: Przewoz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Przewoz przewoz = db.Przewoz.Find(id);
            db.Przewoz.Remove(przewoz);
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
