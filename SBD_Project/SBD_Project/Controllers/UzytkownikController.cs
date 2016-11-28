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
    public class UzytkownikController : Controller
    {
        private SBD_DBEntities db = new SBD_DBEntities();

        // GET: Uzytkownik
        public ActionResult Index()
        {
            var uzytkownik = db.Uzytkownik.Include(u => u.Kierowca).Include(u => u.Pracownik).Include(u => u.Serwis);
            return View(uzytkownik.ToList());
        }

        // GET: Uzytkownik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzytkownik uzytkownik = db.Uzytkownik.Find(id);
            if (uzytkownik == null)
            {
                return HttpNotFound();
            }
            return View(uzytkownik);
        }

        // GET: Uzytkownik/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Kierowca, "FK_Uzytkownik", "Nazwisko");
            ViewBag.ID = new SelectList(db.Pracownik, "FK_Uzytkownik", "Nazwisko");
            ViewBag.ID = new SelectList(db.Serwis, "FK_Uzytkownik", "Nazwa");
            return View();
        }

        // POST: Uzytkownik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Login,Hasło,Typ")] Uzytkownik uzytkownik)
        {
            if (ModelState.IsValid)
            {
                db.Uzytkownik.Add(uzytkownik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Kierowca, "FK_Uzytkownik", "Nazwisko", uzytkownik.ID);
            ViewBag.ID = new SelectList(db.Pracownik, "FK_Uzytkownik", "Nazwisko", uzytkownik.ID);
            ViewBag.ID = new SelectList(db.Serwis, "FK_Uzytkownik", "Nazwa", uzytkownik.ID);
            return View(uzytkownik);
        }

        // GET: Uzytkownik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzytkownik uzytkownik = db.Uzytkownik.Find(id);
            if (uzytkownik == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Kierowca, "FK_Uzytkownik", "Nazwisko", uzytkownik.ID);
            ViewBag.ID = new SelectList(db.Pracownik, "FK_Uzytkownik", "Nazwisko", uzytkownik.ID);
            ViewBag.ID = new SelectList(db.Serwis, "FK_Uzytkownik", "Nazwa", uzytkownik.ID);
            return View(uzytkownik);
        }

        // POST: Uzytkownik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Login,Hasło,Typ")] Uzytkownik uzytkownik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uzytkownik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Kierowca, "FK_Uzytkownik", "Nazwisko", uzytkownik.ID);
            ViewBag.ID = new SelectList(db.Pracownik, "FK_Uzytkownik", "Nazwisko", uzytkownik.ID);
            ViewBag.ID = new SelectList(db.Serwis, "FK_Uzytkownik", "Nazwa", uzytkownik.ID);
            return View(uzytkownik);
        }

        // GET: Uzytkownik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzytkownik uzytkownik = db.Uzytkownik.Find(id);
            if (uzytkownik == null)
            {
                return HttpNotFound();
            }
            return View(uzytkownik);
        }

        // POST: Uzytkownik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uzytkownik uzytkownik = db.Uzytkownik.Find(id);
            db.Uzytkownik.Remove(uzytkownik);
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
