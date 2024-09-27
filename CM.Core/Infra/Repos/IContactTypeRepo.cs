using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.Core.Entities;
using CM.Core.Models.FilterModels;

namespace CM.Core.Infra.Repos
{
    public interface IContactTypeRepo : IGenericRepository<ContactType>
    {
        ContactType FindByName(string name);
        ContactType FindByNameExceptMe(long id, string name);
        IEnumerable<ContactType> GetFilterable(ContactTypeFilterModel filter);  
    }
}
