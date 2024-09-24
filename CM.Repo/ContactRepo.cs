using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.Core.Entities;
using CM.Core.Infra.Repos;
using CM.Core.Models.FilterModels;

namespace CM.Repo
{
    public class ContactRepo: GenericRepository<Contact>, IContactRepo
    {
        public ContactRepo(CMDBContext context) : base(context)
        {
        }

        public Task<IEnumerable<Contact>> GetFilterable(ContactFilterModel filter)
        {
            throw new NotImplementedException();
        }
    }
}
