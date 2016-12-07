using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBD_Project.Models
{
    public class PrzesylkiKierowcy
    {
        public int IDPrzesylki { get; set; }
        public string NumerRejestracyjny { get; set; }
        public DateTime DataPrzewozu { get; set; }
    }
}