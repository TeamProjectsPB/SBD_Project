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
    public class NadaniesController : Controller
    {
        private SBD_DBEntities db = new SBD_DBEntities();

        // GET: Nadanies
        public ActionResult Index()
        {
            var nadanie = db.Nadanie.Include(n => n.Klient);
            return View(nadanie.ToList());
        }

        // GET: Nadanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nadanie nadanie = db.Nadanie.Find(id);
            if (nadanie == null)
            {
                return HttpNotFound();
            }
            return View(nadanie);
        }

        // GET: Nadanies/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Klient, "ID", "Imie");
            return View();
        }

        // POST: Nadanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FK_Klient,Data")] Nadanie nadanie)
        {
            if (ModelState.IsValid)
            {
                db.Nadanie.Add(nadanie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Klient, "ID", "Imie", nadanie.ID);
            return View(nadanie);
        }

        // GET: Nadanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nadanie nadanie = db.Nadanie.Find(id);
            if (nadanie == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Klient, "ID", "Imie", nadanie.ID);
            return View(nadanie);
        }

        // POST: Nadanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FK_Klient,Data")] Nadanie nadanie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nadanie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Klient, "ID", "Imie", nadanie.ID);
            return View(nadanie);
        }

        // GET: Nadanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nadanie nadanie = db.Nadanie.Find(id);
            if (nadanie == null)
            {
                return HttpNotFound();
            }
            return View(nadanie);
        }

        // POST: Nadanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nadanie nadanie = db.Nadanie.Find(id);
            db.Nadanie.Remove(nadanie);
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
