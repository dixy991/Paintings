//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Slizlba.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Slika
    {
        public Slika()
        {
            this.IzlozbaSlikas = new HashSet<IzlozbaSlika>();
            this.SlikaAutors = new HashSet<SlikaAutor>();
            this.SlikaTehnikas = new HashSet<SlikaTehnika>();
        }
    
        public int Id { get; set; }
        public string Naziv { get; set; }
        public Nullable<System.DateTime> Datum { get; set; }
        public Nullable<decimal> Cena { get; set; }
    
        public virtual ICollection<IzlozbaSlika> IzlozbaSlikas { get; set; }
        public virtual ICollection<SlikaAutor> SlikaAutors { get; set; }
        public virtual ICollection<SlikaTehnika> SlikaTehnikas { get; set; }
    }
}
