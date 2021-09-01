using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slizlba.BusinessLayer
{
    public class OperationManager
    {
        private static volatile OperationManager singleton;
        private static object syncobject = new object();
        public OperationManager()
        {

        }

        public static OperationManager Insance
        {
            get
            {
                if (OperationManager.singleton == null)
                {
                    lock (syncobject)
                    {
                        if (singleton == null)
                            singleton = new OperationManager();
                    }
                }
                return singleton;
            }
        }

        public OperationResult executeOperation(Operation op)
        {
            try
            {
                return op.execute();
            }
            catch (Exception ex)
            {
                OperationResult or = new OperationResult();
                or.Succeess = false;
                or.Message = ex.ToString();
                return or;
                throw;
            }
        }
    }
}
