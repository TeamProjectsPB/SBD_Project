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
    
    public partial class Nadanie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nadanie()
        {
            this.Zlecenie = new HashSet<Zlecenie>();
        }
    
        public int ID { get; set; }
        public int FK_Klient { get; set; }
        public System.DateTime Data { get; set; }
    
        public virtual Klient Klient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zlecenie> Zlecenie { get; set; }
    }
}
