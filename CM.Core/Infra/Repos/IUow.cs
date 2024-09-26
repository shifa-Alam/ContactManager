using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Core.Infra.Repos
{
    public interface IUow : IDisposable 
    {
        IContactRepo ContactRepo { get; }   
        IContactGroupRepo ContactGroupRepo { get; }
        IContactTypeRepo ContactTypeRepo { get; }

        int  SaveChanges();
    }
}
