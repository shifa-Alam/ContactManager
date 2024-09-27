using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.Core.Entities;
using CM.Core.Infra.Repos;
using CM.Core.Models.FilterModels;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace CM.Repo
{
    public class ContactTypeRepo : GenericRepository<ContactType>, IContactTypeRepo
    {
        public ContactTypeRepo(CMDBContext context) : base(context)
        {
        }

        public ContactType FindByName(string name)
        {
            return context.ContactTypes.FirstOrDefault(e => e.Name.Equals(name));
        }


        public ContactType FindByNameExceptMe(long id, string name)
        {
            return context.ContactTypes.FirstOrDefault(e => e.Id != id && e.Name.Equals(name));
        }


        public IEnumerable<ContactType> GetFilterable(ContactTypeFilterModel filter)
        {
            IQueryable<ContactType> queryResult = context.ContactTypes;

            queryResult = queryResult.Where(e =>
                (!string.IsNullOrEmpty(filter.Name) ? (e.Name.Contains(filter.Name)) : true)
                && e.Active == true);

            var pagedData = queryResult.ToPagedList(filter.PageNumber, filter.PageSize);
            return pagedData;

        }
    }
}
