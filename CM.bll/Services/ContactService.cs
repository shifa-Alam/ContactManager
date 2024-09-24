using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.Core.Entities;
using CM.Core.Infra.Repos;
using CM.Core.Models.FilterModels;
using CM.Core.Services;

namespace CM.bll.Services
{
    public class ContactService:BaseService,IContactService
    {
        private IUow _uow;

        public ContactService(IUow uow)
        {
            _uow = uow;
        }

        public void Save(Contact entity)
        {
           _uow.ContactRepo.Add(entity);
           _uow.Save();
        }

        public void Update(Contact entity)
        {
            var existingEntity = _uow.ContactRepo.GetById(entity.Id);
            if (existingEntity.Result != null)
            {
                existingEntity.Result.Name
            }
        }

        public void DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contact>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contact>> GetFilterable(ContactFilterModel filter)
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
