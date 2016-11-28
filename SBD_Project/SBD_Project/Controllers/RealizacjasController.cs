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
    public class RealizacjasController : Controller
    {
        private SBD_DBEntities db = new SBD_DBEntities();

        // GET: Realizacjas
        public ActionResult Index()
        {
            return View(db.Realizacja.ToList());
        }

        // GET: Realizacjas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realizacja realizacja = db.Realizacja.Find(id);
            if (realizacja == null)
            {
                return HttpNotFound();
            }
            return View(realizacja);
        }

        // GET: Realizacjas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Realizacjas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Status")] Realizacja realizacja)
        {
            if (ModelState.IsValid)
            {
                db.Realizacja.Add(realizacja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(realizacja);
        }

        // GET: Realizacjas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realizacja realizacja = db.Realizacja.Find(id);
            if (realizacja == null)
            {
                return HttpNotFound();
            }
            return View(realizacja);
        }

        // POST: Realizacjas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Status")] Realizacja realizacja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(realizacja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(realizacja);
        }

        // GET: Realizacjas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realizacja realizacja = db.Realizacja.Find(id);
            if (realizacja == null)
            {
                return HttpNotFound();
            }
            return View(realizacja);
        }

        // POST: Realizacjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Realizacja realizacja = db.Realizacja.Find(id);
            db.Realizacja.Remove(realizacja);
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
