using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.Core.Entities;
using CM.Core.Infra.Repos;

namespace CM.Repo
{
    public class ContactTypeRepo : GenericRepository<ContactType>, IContactTypeRepo
    {
        public ContactTypeRepo(CMDBContext context) : base(context)
        {
        }
    }
}
