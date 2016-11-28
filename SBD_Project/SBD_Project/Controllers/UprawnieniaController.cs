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
    public class UprawnieniaController : Controller
    {
        private SBD_DBEntities db = new SBD_DBEntities();

        // GET: Uprawnienia
        public ActionResult Index()
        {
            var uprawnienia = db.Uprawnienia.Include(u => u.Kierowca);
            return View(uprawnienia.ToList());
        }

        // GET: Uprawnienia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uprawnienia uprawnienia = db.Uprawnienia.Find(id);
            if (uprawnienia == null)
            {
                return HttpNotFound();
            }
            return View(uprawnienia);
        }

        // GET: Uprawnienia/Create
        public ActionResult Create()
        {
            ViewBag.FK_Kierowca = new SelectList(db.Kierowca, "FK_Uzytkownik", "Nazwisko");
            return View();
        }

        // POST: Uprawnienia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FK_Kierowca,NumerUprawnienia,Opis,DataOd,DataDo")] Uprawnienia uprawnienia)
        {
            if (ModelState.IsValid)
            {
                db.Uprawnienia.Add(uprawnienia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Kierowca = new SelectList(db.Kierowca, "FK_Uzytkownik", "Nazwisko", uprawnienia.FK_Kierowca);
            return View(uprawnienia);
        }

        // GET: Uprawnienia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uprawnienia uprawnienia = db.Uprawnienia.Find(id);
            if (uprawnienia == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Kierowca = new SelectList(db.Kierowca, "FK_Uzytkownik", "Nazwisko", uprawnienia.FK_Kierowca);
            return View(uprawnienia);
        }

        // POST: Uprawnienia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FK_Kierowca,NumerUprawnienia,Opis,DataOd,DataDo")] Uprawnienia uprawnienia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uprawnienia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Kierowca = new SelectList(db.Kierowca, "FK_Uzytkownik", "Nazwisko", uprawnienia.FK_Kierowca);
            return View(uprawnienia);
        }

        // GET: Uprawnienia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uprawnienia uprawnienia = db.Uprawnienia.Find(id);
            if (uprawnienia == null)
            {
                return HttpNotFound();
            }
            return View(uprawnienia);
        }

        // POST: Uprawnienia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uprawnienia uprawnienia = db.Uprawnienia.Find(id);
            db.Uprawnienia.Remove(uprawnienia);
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
