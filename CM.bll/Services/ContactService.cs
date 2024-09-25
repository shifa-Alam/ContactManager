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
    public class ContactService : BaseService, IContactService
    {
        private IUow _repo;

        public ContactService(IUow repo)
        {
            _repo = repo;
        }

        public void Save(Contact entity)
        {
            try
            {
                entity.Active = true;
                entity.CreatedDate = DateTime.Now;
                ApplyValidation(entity);
                _repo.ContactRepo.Add(entity);
                _repo.Save();
            }
            catch (Exception e)
            {
                throw ;
            }
           
        }

        private void ApplyValidation(Contact entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrEmpty(entity.Name)) throw new Exception("Name is required");
            if (string.IsNullOrEmpty(entity.PhoneNumber)) throw new Exception("Phone is required");
            if (entity.ContactGroupId<=0) throw new Exception("Group is required");
            if (entity.ContactTypeId<=0) throw new Exception("Type is required");
        }

        public void Update(Contact entity)
        {
            var existingEntity = _repo.ContactRepo.GetById(entity.Id);
            if (existingEntity != null)
            {
                existingEntity.Name = entity.Name;
                existingEntity.PhoneNumber = entity.PhoneNumber;
                existingEntity.ContactTypeId = entity.ContactTypeId;
                existingEntity.ModifiedDate = DateTime.Now;
                _repo.ContactRepo.Update(existingEntity);
                _repo.Save();
            }
        }

        public void DeleteById(long id)
        {
            var entity = _repo.ContactRepo.GetById(id);
            _repo.ContactRepo.Remove(entity);
            _repo.Save();
        }

        public Contact FindById(long id)
        {
            return _repo.ContactRepo.GetById(id);
        }

        public IEnumerable<Contact> Get()
        {
            return _repo.ContactRepo.GetAll();
        }

        public IEnumerable<Contact> GetFilterable(ContactFilterModel filter)
        {
            return _repo.ContactRepo.GetFilterable(filter);
        }

        public override void Dispose()
        {
            _repo.Dispose();
        }
    }
}
