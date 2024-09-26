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
        void Save(Contact entity);
        void Update(Contact entity);
        void DeleteById(long id);
       Contact FindById(long id);
       IEnumerable<Contact> GetAsync();
        IEnumerable<Contact> GetFilterable(ContactFilterModel filter);
    }
}
