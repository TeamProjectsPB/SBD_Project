//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SBD_Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Przewoz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Przewoz()
        {
            this.Paczka = new HashSet<Paczka>();
        }
    
        public int ID { get; set; }
        public int FK_Samochod { get; set; }
        public int FK_Kierowca { get; set; }
        public System.DateTime DataPrzewozu { get; set; }
    
        public virtual Kierowca Kierowca { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paczka> Paczka { get; set; }
        public virtual Samochod Samochod { get; set; }
    }
}
