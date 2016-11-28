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
    public class ZlecenieController : Controller
    {
        private SBD_DBEntities db = new SBD_DBEntities();

        // GET: Zlecenie
        public ActionResult Index()
        {
            var zlecenie = db.Zlecenie.Include(z => z.Nadanie).Include(z => z.Odbior).Include(z => z.Pracownik).Include(z => z.Realizacja);
            return View(zlecenie.ToList());
        }

        // GET: Zlecenie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zlecenie zlecenie = db.Zlecenie.Find(id);
            if (zlecenie == null)
            {
                return HttpNotFound();
            }
            return View(zlecenie);
        }

        // GET: Zlecenie/Create
        public ActionResult Create()
        {
            ViewBag.FK_Nadanie = new SelectList(db.Nadanie, "ID", "ID");
            ViewBag.FK_Odbior = new SelectList(db.Odbior, "ID", "ID");
            ViewBag.FK_Pracownik = new SelectList(db.Pracownik, "FK_Uzytkownik", "Nazwisko");
            ViewBag.FK_Realizacja = new SelectList(db.Realizacja, "ID", "Status");
            return View();
        }

        // POST: Zlecenie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FK_Realizacja,FK_Nadanie,FK_Odbior,FK_Pracownik,Lokalizacja,DataZlecenia")] Zlecenie zlecenie)
        {
            if (ModelState.IsValid)
            {
                db.Zlecenie.Add(zlecenie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Nadanie = new SelectList(db.Nadanie, "ID", "ID", zlecenie.FK_Nadanie);
            ViewBag.FK_Odbior = new SelectList(db.Odbior, "ID", "ID", zlecenie.FK_Odbior);
            ViewBag.FK_Pracownik = new SelectList(db.Pracownik, "FK_Uzytkownik", "Nazwisko", zlecenie.FK_Pracownik);
            ViewBag.FK_Realizacja = new SelectList(db.Realizacja, "ID", "Status", zlecenie.FK_Realizacja);
            return View(zlecenie);
        }

        // GET: Zlecenie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zlecenie zlecenie = db.Zlecenie.Find(id);
            if (zlecenie == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Nadanie = new SelectList(db.Nadanie, "ID", "ID", zlecenie.FK_Nadanie);
            ViewBag.FK_Odbior = new SelectList(db.Odbior, "ID", "ID", zlecenie.FK_Odbior);
            ViewBag.FK_Pracownik = new SelectList(db.Pracownik, "FK_Uzytkownik", "Nazwisko", zlecenie.FK_Pracownik);
            ViewBag.FK_Realizacja = new SelectList(db.Realizacja, "ID", "Status", zlecenie.FK_Realizacja);
            return View(zlecenie);
        }

        // POST: Zlecenie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FK_Realizacja,FK_Nadanie,FK_Odbior,FK_Pracownik,Lokalizacja,DataZlecenia")] Zlecenie zlecenie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zlecenie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Nadanie = new SelectList(db.Nadanie, "ID", "ID", zlecenie.FK_Nadanie);
            ViewBag.FK_Odbior = new SelectList(db.Odbior, "ID", "ID", zlecenie.FK_Odbior);
            ViewBag.FK_Pracownik = new SelectList(db.Pracownik, "FK_Uzytkownik", "Nazwisko", zlecenie.FK_Pracownik);
            ViewBag.FK_Realizacja = new SelectList(db.Realizacja, "ID", "Status", zlecenie.FK_Realizacja);
            return View(zlecenie);
        }

        // GET: Zlecenie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zlecenie zlecenie = db.Zlecenie.Find(id);
            if (zlecenie == null)
            {
                return HttpNotFound();
            }
            return View(zlecenie);
        }

        // POST: Zlecenie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zlecenie zlecenie = db.Zlecenie.Find(id);
            db.Zlecenie.Remove(zlecenie);
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
