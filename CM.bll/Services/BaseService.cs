using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.bll.Services
{
    public abstract class BaseService:IDisposable
    {
        public abstract void Dispose();
    }
}
