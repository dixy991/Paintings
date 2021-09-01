using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Slizlba.BusinessLayer
{
    public class getAutoriOp:EfOperation
    {
        private int id;

        public getAutoriOp(int id)
        {
            this.id = id;
        }

        public override OperationResult execute()
        {
            var nadji = this.Buza.SlikaAutors.Where(x => x.idSlika == id).Select(x => new DtoAutor
            {
                Id = x.idAutor,
                Ime = x.Autor.Ime,
                Prezime = x.Autor.Prezime
            });

            return new OperationCollection
            {
                Data = nadji.ToArray()
            };
        }
    }
}
