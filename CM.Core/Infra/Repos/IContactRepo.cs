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
        Task<IEnumerable<Contact>> GetFilterable(ContactFilterModel filter);
    }
}
