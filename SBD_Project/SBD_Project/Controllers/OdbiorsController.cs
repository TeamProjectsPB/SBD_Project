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
    public class OdbiorsController : Controller
    {
        private SBD_DBEntities db = new SBD_DBEntities();

        // GET: Odbiors
        public ActionResult Index()
        {
            var odbior = db.Odbior.Include(o => o.Klient);
            return View(odbior.ToList());
        }

        // GET: Odbiors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odbior odbior = db.Odbior.Find(id);
            if (odbior == null)
            {
                return HttpNotFound();
            }
            return View(odbior);
        }

        // GET: Odbiors/Create
        public ActionResult Create()
        {
            ViewBag.FK_Klient = new SelectList(db.Klient, "ID", "ImieNazwisko");
            return View();
        }

        // POST: Odbiors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FK_Klient,Data")] Odbior odbior)
        {
            if (ModelState.IsValid)
            {
                db.Odbior.Add(odbior);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Klient = new SelectList(db.Klient, "ID", "ImieNazwisko", odbior.FK_Klient);
            return View(odbior);
        }

        // GET: Odbiors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odbior odbior = db.Odbior.Find(id);
            if (odbior == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Klient = new SelectList(db.Klient, "ID", "ImieNazwisko", odbior.FK_Klient);
            return View(odbior);
        }

        // POST: Odbiors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FK_Klient,Data")] Odbior odbior)
        {
            if (ModelState.IsValid)
            {
                db.Entry(odbior).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Klient = new SelectList(db.Klient, "ID", "ImieNazwisko", odbior.FK_Klient);
            return View(odbior);
        }

        // GET: Odbiors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odbior odbior = db.Odbior.Find(id);
            if (odbior == null)
            {
                return HttpNotFound();
            }
            return View(odbior);
        }

        // POST: Odbiors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Odbior odbior = db.Odbior.Find(id);
            db.Odbior.Remove(odbior);
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
