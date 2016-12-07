//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBD_Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Klient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Klient()
        {
            this.Nadanie = new HashSet<Nadanie>();
            this.Odbior = new HashSet<Odbior>();
        }
    
        public int ID { get; set; }
        [Display(Name = "Imi�")]
        public string Imie { get; set; }

        [Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Kod Pocztowy")]
        public string KodPocztowy { get; set; }

        [Display(Name = "Miasto")]
        public string Miasto { get; set; }

        [Display(Name = "Ulica")]
        public string Ulica { get; set; }

        [Display(Name = "Numer domu")]
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        public decimal NumerDomu { get; set; }

        [Display(Name = "Numer mieszkania")]
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        public Nullable<decimal> NumerMieszkania { get; set; }

        [Display(Name = "Telefon")]
        [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)]
        public decimal Telefon { get; set; }

        [NotMapped]
        [Display(Name = "Imi� i nazwisko")]
        public string ImieNazwisko { get { return Imie + " " + Nazwisko; } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nadanie> Nadanie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Odbior> Odbior { get; set; }
    }
}
