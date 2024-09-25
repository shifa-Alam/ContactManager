using CM.Core.Entities;
using CM.Core.Models.FilterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Core.Services
{
    public interface IContactTypeService:IDisposable
    {
        public void Save(ContactType entity);
        public void Update(ContactType entity);
        public void DeleteById(long id);
        public ContactType FindById(long id);
        public IEnumerable<ContactType> Get();
        public IEnumerable<ContactType> GetFilterable(ContactTypeFilterModel filter);
    }
}
