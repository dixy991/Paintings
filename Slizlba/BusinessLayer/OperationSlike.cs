using Slizlba.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slizlba.BusinessLayer
{
    public class OperationSlikeBase : EfOperation
    {
        public override OperationResult execute()
        {
            var slike = this.Buza.Slikas.Select(x => new DtoSlike
            {
                Cena = x.Cena,
                Datum = x.Datum,
                Naziv = x.Naziv,
                Id = x.Id
            });

            return new OperationCollection
            {
                Data = slike.ToArray()
            };
        }
    }

    public class OperationSlikeSelect : OperationSlikeBase
    {

    }

    public abstract class OperationSlikeEdit : OperationSlikeBase
    {
        public abstract void UradiEdit();
        public DtoSlike Slika { get; set; }

        public override OperationResult execute()
        {
            this.UradiEdit();
            this.Buza.SaveChanges();

            if (Rezultat)
                return base.execute();
            else
                return new OperationResult();
        }
    }

    public class OperationSlikeInsert : EfOperation
    {
        public DtoSlike Slika { get; set; }
        public int[] Autori { get; set; }

        public override OperationResult execute()
        {
            var slika = new Slika
            {
                Cena = Slika.Cena,
                Datum = Slika.Datum,
                Naziv = Slika.Naziv
            };

            if (Autori != null)
            {
                foreach (var item in Autori)
                {
                    var autor = new SlikaAutor
                    {
                        idAutor = item,
                        idSlika = slika.Id
                    };
                    slika.SlikaAutors.Add(autor);
                }
            }
            this.Buza.Slikas.Add(slika);
            this.Buza.SaveChanges();
            return new OperationResult();
        }
    }

    public class OperationSlikeUpdate : OperationSlikeEdit
    {
        public override void UradiEdit()
        {
            var nadji = this.Buza.Slikas.Find(Slika.Id);
            nadji.Cena = Slika.Cena;
            nadji.Datum = Slika.Datum;
            nadji.Naziv = Slika.Naziv;
        }
    }

    public class OperationSlikeDelete : OperationSlikeEdit
    {
        public override void UradiEdit()
        {
            var nadji = this.Buza.Slikas.Find(Slika.Id);
            this.Buza.Slikas.Remove(nadji);

            foreach (var item in this.Buza.SlikaAutors)
            {
                if (item.idSlika == Slika.Id)
                    this.Buza.SlikaAutors.Remove(item);
            }
        }
    }
}
