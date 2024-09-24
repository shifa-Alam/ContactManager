using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CM.Core.Entities;
using CM.Core.Models.FilterModels;

namespace CM.Core.Services
{
    public interface IContactService : IDisposable
    {
        public void Save(Contact entity);
        public void Update(Contact entity);
        public void DeleteById(long id);
        public Contact FindById(long id);
        public IEnumerable<Contact> Get();
        public IEnumerable<Contact> GetFilterable(ContactFilterModel filter);
    }
}
