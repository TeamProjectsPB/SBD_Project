using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SBD_Project.Models;

namespace SBD_Project.Controllers
{
    public class CreateNewPackageController : Controller
    {
        bool odbiorcaInserted,
            odbiorInserted,
            nadawcaInserted,
            nadanieInserted,
            zlecenieInserted,
            przewozCreatedOrFound,
            paczkaInserted;
        private SBD_DBEntities db = new SBD_DBEntities();
        // GET: CreateNewPackage
        [Authorize(Roles = "Pracownik")]
        public ActionResult Create()
        {           
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Pracownik")]
        public ActionResult Create(AllModels allModel)
        {
            if (ModelState.IsValid)
            {
                try
                {                    
                    allModel.Odbior.Klient = allModel.Odbiorca;
                    allModel.Nadanie.Klient = allModel.Nadawca;                    

                    allModel.Zlecenie.Odbior = allModel.Odbior;
                    allModel.Zlecenie.Nadanie = allModel.Nadanie;
                    allModel.Zlecenie.FK_Realizacja = 1;

                    var userId = User.Identity.GetUserId();
                    allModel.Zlecenie.Pracownik =
                        db.Pracownik.Where(p => p.FK_Uzytkownik.ToString().Equals(userId))
                            .FirstOrDefault();
                    
                    var data = allModel.Odbior.Data;

                    bool przewozExists = false;
                    var przewoz =
                        db.Przewoz.Where(p => p.DataPrzewozu.Equals(data)).FirstOrDefault();
                    if (przewoz == null)
                    {
                        var freeDriver =
                            db.Kierowca.Where(k => k.Przewoz.Where(p => p.DataPrzewozu.Equals(data)).Count() == 0)
                                .FirstOrDefault();

                        if (freeDriver == null)
                        {
                            allModel.ValidationSummary += data.ToShortDateString() +
                                                          ": nie znaleziono wolnego kierowcy. Zmień datę odbioru.";
                            return View(allModel);
                        }
                        var freeCar =
                            db.Samochod.Where(s => s.Przewoz.Where(p => p.DataPrzewozu.Equals(data)).Count() == 0)
                                .FirstOrDefault();
                        if (freeCar == null)
                        {
                            allModel.ValidationSummary += data.ToShortDateString() +
                                                          ": nie znaleziono wolnego pojazdu. Zmień datę odbioru.";
                            return View(allModel);
                        }
                        przewoz = new Przewoz();
                        przewoz.DataPrzewozu = data;
                        przewoz.Kierowca = freeDriver;
                        przewoz.Samochod = freeCar;
                    }
                    else
                    {
                        przewozExists = true;
                    }

                    allModel.Paczka.Przewoz = przewoz;
                    allModel.Paczka.Zlecenie = allModel.Zlecenie;
                    db.Paczka.Add(allModel.Paczka);
                    db.SaveChanges();                    
                }
                catch (Exception e) { }
            }
            return View(allModel);
        }

        public ActionResult SuccesfullyCreated()
        {
            return View();

        }
    }
}