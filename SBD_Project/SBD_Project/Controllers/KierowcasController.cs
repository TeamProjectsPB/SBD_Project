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
    public class KierowcasController : Controller
    {
        private SBD_DBEntities db = new SBD_DBEntities();

        // GET: Kierowcas
        public ActionResult Index()
        {
            var kierowca = db.Kierowca.Include(k => k.Uzytkownik);
            return View(kierowca.ToList());
        }

        // GET: Kierowcas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kierowca kierowca = db.Kierowca.Find(id);
            if (kierowca == null)
            {
                return HttpNotFound();
            }
            return View(kierowca);
        }

        // GET: Kierowcas/Create
        public ActionResult Create()
        {
            ViewBag.FK_Uzytkownik = new SelectList(db.Uzytkownik, "ID", "Login");
            return View();
        }

        // POST: Kierowcas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FK_Uzytkownik,Nazwisko,Imie,KodPocztowy,Miasto,Ulica,NumerDomu,NumerMieszkania,Telefon")] Kierowca kierowca)
        {
            if (ModelState.IsValid)
            {
                db.Kierowca.Add(kierowca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Uzytkownik = new SelectList(db.Uzytkownik, "ID", "Login", kierowca.FK_Uzytkownik);
            return View(kierowca);
        }

        // GET: Kierowcas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kierowca kierowca = db.Kierowca.Find(id);
            if (kierowca == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Uzytkownik = new SelectList(db.Uzytkownik, "ID", "Login", kierowca.FK_Uzytkownik);
            return View(kierowca);
        }

        // POST: Kierowcas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FK_Uzytkownik,Nazwisko,Imie,KodPocztowy,Miasto,Ulica,NumerDomu,NumerMieszkania,Telefon")] Kierowca kierowca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kierowca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Uzytkownik = new SelectList(db.Uzytkownik, "ID", "Login", kierowca.FK_Uzytkownik);
            return View(kierowca);
        }

        // GET: Kierowcas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kierowca kierowca = db.Kierowca.Find(id);
            if (kierowca == null)
            {
                return HttpNotFound();
            }
            return View(kierowca);
        }

        // POST: Kierowcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kierowca kierowca = db.Kierowca.Find(id);
            db.Kierowca.Remove(kierowca);
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
