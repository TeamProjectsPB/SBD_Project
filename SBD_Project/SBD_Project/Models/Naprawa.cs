//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace SBD_Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Naprawa
    {
        public int ID { get; set; }

        [Display(Name="Samoch�d")]
        public int FK_Samochod { get; set; }

        [Display(Name = "Serwis")]
        public int FK_Serwis { get; set; }

        [Display(Name = "Data Oddania")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime DataOddania { get; set; }

        [Display(Name = "Data Odbioru")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime DataOdbioru { get; set; }

        [Display(Name = "Opis")]
        public string Opis { get; set; }
    
        public virtual Samochod Samochod { get; set; }
        public virtual Serwis Serwis { get; set; }
    }
}
