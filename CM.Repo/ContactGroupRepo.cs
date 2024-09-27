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
    public class ContactGroupRepo: GenericRepository<ContactGroup>,IContactGroupRepo
    {
        public ContactGroupRepo(CMDBContext context) : base(context)
        {
        }

        public ContactGroup FindByName(string name)
        {
            return context.ContactGroups.FirstOrDefault(e => e.Name.Equals(name));
        }

        public ContactGroup FindByNameExceptMe(long id, string name)
        {
            return context.ContactGroups.FirstOrDefault(e => e.Id != id && e.Name.Equals(name));
        }

        public IEnumerable<ContactGroup> GetFilterable(ContactGroupFilterModel filter)
        {
            IQueryable<ContactGroup> queryResult = context.ContactGroups;

            queryResult = queryResult.Where(e =>
                (!string.IsNullOrEmpty(filter.Name) ? (e.Name.Contains(filter.Name)) : true)
               
                && e.Active == true);

            var pagedData = queryResult.ToPagedList(filter.PageNumber, filter.PageSize);
            return pagedData;

        }
    }
}
