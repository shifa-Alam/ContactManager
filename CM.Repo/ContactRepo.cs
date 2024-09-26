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
    public class ContactRepo : GenericRepository<Contact>, IContactRepo
    {
        public ContactRepo(CMDBContext context) : base(context)
        {
        }

        public Contact FindByNameAndNumber(string name, string phoneNumber)
        {
            return context.Contacts.FirstOrDefault(e => e.Name.Equals(name) && e.PhoneNumber.Equals(phoneNumber));
        }
        public Contact FindByNameAndNumberExceptMe(long id, string name, string phoneNumber)
        {
            return context.Contacts.FirstOrDefault(e => e.Id != id && e.Name.Equals(name) && e.PhoneNumber.Equals(phoneNumber));
        }

        public IEnumerable<Contact> GetFilterable(ContactFilterModel filter)
        {
            IQueryable<Contact> queryResult = context.Contacts.Include(c => c.ContactGroup).Include(c => c.ContactType);

            queryResult = queryResult.Where(e =>
                (!string.IsNullOrWhiteSpace(filter.Name) ? (e.Name.Contains(filter.Name)) : true)
                && (!string.IsNullOrWhiteSpace(filter.PhoneNumber) ? e.PhoneNumber.Contains(filter.PhoneNumber) : true)
                && (filter.ContactTypeId > 0 ? e.ContactTypeId == filter.ContactTypeId : true)
                && (filter.ContactGroupId > 0 ? (e.ContactGroupId == filter.ContactGroupId) : true)
                && e.Active == true);

            var pagedData = queryResult.ToPagedList(filter.PageNumber, filter.PageSize);
            return pagedData;

        }
    }
}
