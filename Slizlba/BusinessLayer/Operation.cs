using Slizlba.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slizlba.BusinessLayer
{
    public abstract class Operation
    {
        public abstract OperationResult execute();
        public bool Rezultat { get; set; } = true;
    }

    public class OperationResult
    {
        public bool Succeess { get; set; } = true;
        public string Message { get; set; }
    }

    public class OperationCollection : OperationResult
    {
        public DtoBase[] Data { get; set; }
    }

    public abstract class EfOperation : Operation
    {
        private SlilzozbeEntities buza = new SlilzozbeEntities();
        public SlilzozbeEntities Buza => buza;
    }
}
