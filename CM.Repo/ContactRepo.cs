using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.Core.Entities;
using CM.Core.Infra.Repos;
using CM.Core.Models.FilterModels;
using X.PagedList;

namespace CM.Repo
{
    public class ContactRepo: GenericRepository<Contact>, IContactRepo
    {
        public ContactRepo(CMDBContext context) : base(context)
        {
        }

        public IEnumerable<Contact> GetFilterable(ContactFilterModel filter)
        {
            IQueryable<Contact> queryResult = context.Contacts;

            queryResult = queryResult.Where(e =>
                (!string.IsNullOrEmpty(filter.Name) ? (e.Name.Contains(filter.Name)) : true)
                && (!string.IsNullOrEmpty(filter.PhoneNumber) ? e.PhoneNumber.Contains(filter.PhoneNumber) : true) 
                && (filter.ContactTypeId>0? e.ContactTypeId==filter.ContactTypeId:true) 
                && (filter.ContactGroupId>0? (e.ContactGroupId==filter.ContactGroupId):true) 
                && e.Active == true);

            var pagedData = queryResult.ToPagedList(filter.PageNumber, filter.PageSize);
            return pagedData;

        }
    }
}
