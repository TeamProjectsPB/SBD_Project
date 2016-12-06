using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBD_Project.Models
{
    public class AllModels
    {
        Odbior odbior;
        Klient odbiorca;

        Nadanie nadanie;
        Klient nadawca;
        Paczka paczka;
        Zlecenie zlecenie;

        string validationSummary = String.Empty;
        public string ValidationSummary
        {
            get { return validationSummary; }
            set { validationSummary = value; }
        }




        public Odbior Odbior
        {
            get { return odbior; }
            set { odbior = value; }
        }



        public Klient Odbiorca
        {
            get { return odbiorca; }
            set { odbiorca = value; }
        }

        public Nadanie Nadanie
        {
            get { return nadanie; }
            set { nadanie = value; }
        }

        public Klient Nadawca
        {
            get { return nadawca; }
            set { nadawca = value; }
        }

        public Paczka Paczka
        {
            get { return paczka; }
            set { paczka = value; }
        }

        public Zlecenie Zlecenie
        {
            get { return zlecenie; }
            set { zlecenie = value; }
        }
    }
}