using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.Core.Entities;
using CM.Core.Models.FilterModels;

namespace CM.Core.Infra.Repos
{
    public interface IContactGroupRepo : IGenericRepository<ContactGroup>
    {
        ContactGroup FindByName(string name);
        ContactGroup FindByNameExceptMe(long id, string name);
        IEnumerable<ContactGroup> GetFilterable(ContactGroupFilterModel filter);
    }
}
