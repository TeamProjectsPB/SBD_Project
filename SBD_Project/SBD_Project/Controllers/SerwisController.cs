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
    public class SerwisController : Controller
    {
        private SBD_DBEntities db = new SBD_DBEntities();

        // GET: Serwis
        public ActionResult Index()
        {
            var serwis = db.Serwis.Include(s => s.Uzytkownik);
            return View(serwis.ToList());
        }

        // GET: Serwis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serwis serwis = db.Serwis.Find(id);
            if (serwis == null)
            {
                return HttpNotFound();
            }
            return View(serwis);
        }

        // GET: Serwis/Create
        public ActionResult Create()
        {
            ViewBag.FK_Uzytkownik = new SelectList(db.Uzytkownik, "ID", "Login");
            return View();
        }

        // POST: Serwis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FK_Uzytkownik,Nazwa,KodPocztowy,Miasto,Ulica,NumerDomu,NumerMieszkania,Telefon")] Serwis serwis)
        {
            if (ModelState.IsValid)
            {
                db.Serwis.Add(serwis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Uzytkownik = new SelectList(db.Uzytkownik, "ID", "Login", serwis.FK_Uzytkownik);
            return View(serwis);
        }

        // GET: Serwis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serwis serwis = db.Serwis.Find(id);
            if (serwis == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Uzytkownik = new SelectList(db.Uzytkownik, "ID", "Login", serwis.FK_Uzytkownik);
            return View(serwis);
        }

        // POST: Serwis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FK_Uzytkownik,Nazwa,KodPocztowy,Miasto,Ulica,NumerDomu,NumerMieszkania,Telefon")] Serwis serwis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serwis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Uzytkownik = new SelectList(db.Uzytkownik, "ID", "Login", serwis.FK_Uzytkownik);
            return View(serwis);
        }

        // GET: Serwis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serwis serwis = db.Serwis.Find(id);
            if (serwis == null)
            {
                return HttpNotFound();
            }
            return View(serwis);
        }

        // POST: Serwis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Serwis serwis = db.Serwis.Find(id);
            db.Serwis.Remove(serwis);
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
