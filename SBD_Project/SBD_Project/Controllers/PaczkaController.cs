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
    public class PaczkaController : Controller
    {
        private SBD_DBEntities db = new SBD_DBEntities();

        // GET: Paczka
        public ActionResult Index()
        {
            var paczka = db.Paczka.Include(p => p.Przewoz).Include(p => p.Zlecenie);
            return View(paczka.ToList());
        }

        // GET: Paczka/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paczka paczka = db.Paczka.Find(id);
            if (paczka == null)
            {
                return HttpNotFound();
            }
            return View(paczka);
        }

        // GET: Paczka/Create
        public ActionResult Create()
        {
            ViewBag.FK_Przewoz = new SelectList(db.Przewoz, "ID", "ID");
            ViewBag.FK_Zlecenie = new SelectList(db.Zlecenie, "ID", "Lokalizacja");
            return View();
        }

        // POST: Paczka/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FK_Zlecenie,FK_Przewoz,Nazwa,Wartosc,Waga,Uwagi")] Paczka paczka)
        {
            if (ModelState.IsValid)
            {
                db.Paczka.Add(paczka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Przewoz = new SelectList(db.Przewoz, "ID", "ID", paczka.FK_Przewoz);
            ViewBag.FK_Zlecenie = new SelectList(db.Zlecenie, "ID", "Lokalizacja", paczka.FK_Zlecenie);
            return View(paczka);
        }

        // GET: Paczka/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paczka paczka = db.Paczka.Find(id);
            if (paczka == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Przewoz = new SelectList(db.Przewoz, "ID", "ID", paczka.FK_Przewoz);
            ViewBag.FK_Zlecenie = new SelectList(db.Zlecenie, "ID", "Lokalizacja", paczka.FK_Zlecenie);
            return View(paczka);
        }

        // POST: Paczka/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FK_Zlecenie,FK_Przewoz,Nazwa,Wartosc,Waga,Uwagi")] Paczka paczka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paczka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Przewoz = new SelectList(db.Przewoz, "ID", "ID", paczka.FK_Przewoz);
            ViewBag.FK_Zlecenie = new SelectList(db.Zlecenie, "ID", "Lokalizacja", paczka.FK_Zlecenie);
            return View(paczka);
        }

        // GET: Paczka/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paczka paczka = db.Paczka.Find(id);
            if (paczka == null)
            {
                return HttpNotFound();
            }
            return View(paczka);
        }

        // POST: Paczka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paczka paczka = db.Paczka.Find(id);
            db.Paczka.Remove(paczka);
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
