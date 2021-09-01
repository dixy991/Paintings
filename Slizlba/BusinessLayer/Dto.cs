using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slizlba.BusinessLayer
{
    public abstract class DtoBase
    {
    }

    public class DtoSlike : DtoBase
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public DateTime? Datum { get; set; }
        public decimal? Cena { get; set; }
    }

    public class DtoSlikaAutor : DtoBase
    {
        public int idSlika { get; set; }
        public int idAutor { get; set; }
    }

    public class DtoAutor : DtoBase
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
    }
}
