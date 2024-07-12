using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDCJupiterLoadModel
{
    public class BaseData : IDisposable
    {
        public void Dispose() 
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
        
    }
}
