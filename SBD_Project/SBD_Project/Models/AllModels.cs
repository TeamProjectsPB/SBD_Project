using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBD_Project.Models
{
    public class AllModels
    {
        private Cennik cennikModel;
        Kierowca kierowcaModel;
        Klient klientModel;
        Nadanie nadanieModel;
        Naprawa naprawaModel;
        Odbior odbiorModel;
        Paczka paczkaModel;
        Pracownik pracownikModel;
        Przewoz przewozModel;
        Realizacja realizacjaModel;
        Samochod samochodModel;
        Serwis serwisModel;
        Uprawnienia uprawnieniaModel;
        Uzytkownik uzytkownikModel;
        Zlecenie zlecenieModel;

        public Cennik CennikModel
        {
            get { return cennikModel; }
            set { cennikModel = value; }
        }

        public Kierowca KierowcaModel
        {
            get { return kierowcaModel; }
            set { kierowcaModel = value; }
        }

        public Klient KlientModel
        {
            get { return klientModel; }
            set { klientModel = value; }
        }

        public Nadanie NadanieModel
        {
            get { return nadanieModel; }
            set { nadanieModel = value; }
        }

        public Naprawa NaprawaModel
        {
            get { return naprawaModel; }
            set { naprawaModel = value; }
        }

        public Odbior OdbiorModel
        {
            get { return odbiorModel; }
            set { odbiorModel = value; }
        }

        public Paczka PaczkaModel
        {
            get { return paczkaModel; }
            set { paczkaModel = value; }
        }

        public Pracownik PracownikModel
        {
            get { return pracownikModel; }
            set { pracownikModel = value; }
        }

        public Przewoz PrzewozModel
        {
            get { return przewozModel; }
            set { przewozModel = value; }
        }

        public Realizacja RealizacjaModel
        {
            get { return realizacjaModel; }
            set { realizacjaModel = value; }
        }

        public Samochod SamochodModel
        {
            get { return samochodModel; }
            set { samochodModel = value; }
        }

        public Serwis SerwisModel
        {
            get { return serwisModel; }
            set { serwisModel = value; }
        }

        public Uprawnienia UprawnieniaModel
        {
            get { return uprawnieniaModel; }
            set { uprawnieniaModel = value; }
        }

        public Uzytkownik UzytkownikModel
        {
            get { return uzytkownikModel; }
            set { uzytkownikModel = value; }
        }

        public Zlecenie ZlecenieModel
        {
            get { return zlecenieModel; }
            set { zlecenieModel = value; }
        }
    }
}