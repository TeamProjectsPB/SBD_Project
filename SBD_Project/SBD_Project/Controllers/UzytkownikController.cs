using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using SBD_Project.Models;

namespace SBD_Project.Controllers
{
    public class UzytkownikController : Controller
    {
        private SBD_DBEntities db = new SBD_DBEntities();

        // GET: Uzytkownik
        [Authorize(Roles="Administrator, Pracownik")]
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
        //public ActionResult Edit([Bind(Include = "ID,Login,Hasło,Typ")] Uzytkownik uzytkownik)
        public ActionResult Edit(Uzytkownik uzytkownik)
        {
            ModelState.Remove("Hasło");
            if (ModelState.IsValid)
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                var user = new Uzytkownik() {ID = uzytkownik.ID, Typ = uzytkownik.Typ};
                    db.Uzytkownik.Attach(user);
                    db.Entry(user).Property(x => x.Typ).IsModified = true;
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

        //Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Uzytkownik user)
        {
            if (ModelState.IsValid)
            {
                user.Typ = String.Empty;
                db.Uzytkownik.Add(user);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = user.Login + " został pomyslnie zarejestrowany";
            }
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Uzytkownik user)
        {
            var usr =
                db.Uzytkownik.Where(u => u.Login.Equals(user.Login) && u.Hasło.Equals(user.Hasło)).FirstOrDefault();
            if (usr != null)
            {
                var ident = new ClaimsIdentity(
          new[] { 
              // adding following 2 claim just for supporting default antiforgery provider
              new Claim(ClaimTypes.NameIdentifier, usr.ID.ToString()),
              new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),

              new Claim(ClaimTypes.Name, usr.Login.ToString()),
              new Claim(ClaimTypes.Role, usr.Typ)
          },
          DefaultAuthenticationTypes.ApplicationCookie);

                HttpContext.GetOwinContext().Authentication.SignIn(
                   new AuthenticationProperties { IsPersistent = false }, ident);
                return RedirectToAction("Index"); // auth succeed 
            }
            else
            {
                ModelState.AddModelError("", "Login lub hasło są złe");
                return View();
            }
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
    }
}