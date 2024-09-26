using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CM.Core.Entities;
using CM.Core.Models.FilterModels;

namespace CM.Core.Infra.Repos
{
    public interface IContactRepo : IGenericRepository<Contact>
    {
        Contact FindByNameAndNumber(string name, string phoneNumber);
        Contact FindByNameAndNumberExceptMe(long id, string name, string phoneNumber);
        IEnumerable<Contact> GetFilterable(ContactFilterModel filter);
    }
}
