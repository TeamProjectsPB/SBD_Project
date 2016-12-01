using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SBD_Project.Models;

namespace SBD_Project.Controllers
{
    public class UprawnieniaController : Controller
    {
        private SBD_DBEntities db = new SBD_DBEntities();

        // GET: Uprawnienia
        [Authorize(Roles = "Administrator, Pracownik")]
        public ActionResult Index()
        {
            //IQueryable<Uprawnienia> uprawnienia;
            //if (id != null)
            //{
            //    uprawnienia = db.Uprawnienia.Include(u => u.Kierowca).Where(u => u.FK_Kierowca == id);
            //}
            //else
            //{
            //    uprawnienia = db.Uprawnienia.Include(u => u.Kierowca);
            //}
            var uprawnienia = db.Uprawnienia.Include(u => u.Kierowca);
            return View(uprawnienia.ToList());
        }
        [Authorize(Roles = "Administrator, Pracownik, Kierowca")]
        public ActionResult IndexUser(int id)
        {
            var uprawnienia = db.Uprawnienia.Include(u => u.Kierowca).Where(u => u.FK_Kierowca == id);
            return View("Index", uprawnienia.ToList());
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
        [Authorize(Roles = "Administrator, Pracownik, Kierowca")]
        public ActionResult Create()
        {
            ViewBag.FK_Kierowca = new SelectList(db.Kierowca, "FK_Uzytkownik", "ImieNazwisko");
            return View();
        }
        
        // POST: Uprawnienia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Pracownik")]
        public ActionResult Create([Bind(Include = "ID,FK_Kierowca,NumerUprawnienia,Opis,DataOd,DataDo")] Uprawnienia uprawnienia)
        {
            if (ModelState.IsValid)
            {
                db.Uprawnienia.Add(uprawnienia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Kierowca = new SelectList(db.Kierowca, "FK_Uzytkownik", "ImieNazwisko", uprawnienia.FK_Kierowca);
            return View(uprawnienia);
        }

        [Authorize(Roles = "Administrator, Pracownik, Kierowca")]
        public ActionResult CreateByUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Pracownik, Kierowca")]
        public ActionResult CreateByUser([Bind(Include = "ID,FK_Kierowca,NumerUprawnienia,Opis,DataOd,DataDo")] Uprawnienia uprawnienia)
        {
            var id = int.Parse(User.Identity.GetUserId());
            uprawnienia.FK_Kierowca = id;
            if (ModelState.IsValid)
            {
                db.Uprawnienia.Add(uprawnienia);
                db.SaveChanges();
                return RedirectToAction("IndexUser", new { id = id });
            }

            ViewBag.FK_Kierowca = new SelectList(db.Kierowca, "FK_Uzytkownik", "ImieNazwisko", uprawnienia.FK_Kierowca);
            return View(uprawnienia);
        }

        // GET: Uprawnienia/Edit/5
        [Authorize(Roles = "Administrator, Pracownik, Kierowca")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uprawnienia uprawnienia = db.Uprawnienia.Find(id);
            if (User.IsInRole("Kierowca") && !uprawnienia.FK_Kierowca.ToString().Equals(User.Identity.GetUserId()))
            {
                return RedirectToAction("IndexUser", new { id = uprawnienia.FK_Kierowca });
            }
            if (uprawnienia == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Kierowca = new SelectList(db.Kierowca, "FK_Uzytkownik", "ImieNazwisko", uprawnienia.FK_Kierowca);
            return View(uprawnienia);
        }

        // POST: Uprawnienia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Pracownik, Kierowca")]
        public ActionResult Edit([Bind(Include = "ID,FK_Kierowca,NumerUprawnienia,Opis,DataOd,DataDo")] Uprawnienia uprawnienia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uprawnienia).State = EntityState.Modified;
                db.SaveChanges();
                if (User.IsInRole("Kierowca"))
                {
                    return RedirectToAction("IndexUser", new { id = uprawnienia.FK_Kierowca });
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.FK_Kierowca = new SelectList(db.Kierowca, "FK_Uzytkownik", "ImieNazwisko", uprawnienia.FK_Kierowca);
            return View(uprawnienia);
        }

        // GET: Uprawnienia/Delete/5
        [Authorize(Roles = "Administrator, Pracownik, Kierowca")]
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
        [Authorize(Roles = "Administrator, Pracownik, Kierowca")]
        public ActionResult DeleteConfirmed(int id)
        {
            Uprawnienia uprawnienia = db.Uprawnienia.Find(id);
            if (User.IsInRole("Kierowca") && uprawnienia.FK_Kierowca.ToString().Equals(User.Identity.GetUserId()))
            {
                return RedirectToAction("IndexUser", new { id = uprawnienia.FK_Kierowca });
            }
            db.Uprawnienia.Remove(uprawnienia);
            db.SaveChanges();
            if (User.IsInRole("Kierowca"))
            {
                return RedirectToAction("IndexUser", new {id = uprawnienia.FK_Kierowca});
            }
            else
            {
                return RedirectToAction("Index");
            }
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
