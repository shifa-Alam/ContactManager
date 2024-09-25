using CM.Core.Entities;
using CM.Core.Models.FilterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Core.Services
{
    public interface IContactGroupService:IDisposable
    {
        public void Save(ContactGroup entity);
        public void Update(ContactGroup entity);
        public void DeleteById(long id);
        public ContactGroup FindById(long id);
        public IEnumerable<ContactGroup> Get();
        public IEnumerable<ContactGroup> GetFilterable(ContactGroupFilterModel filter);

    }
}
