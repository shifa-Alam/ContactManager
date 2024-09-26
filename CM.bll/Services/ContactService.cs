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
        protected IUow Repo;

        public ContactService(IUow repo)
        {
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public Contact Save(Contact entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            entity.Active = true;
            entity.CreatedDate = DateTime.Now;

            ApplyValidation(entity);
            var duplicateEntity = Repo.ContactRepo.FindByNameAndNumber(entity.Name, entity.PhoneNumber);
            ApplyDuplicateBl(duplicateEntity);

            Repo.ContactRepo.Add(entity);
            if (Repo.SaveChanges() <= 0) throw new Exception("Error In save");
            return entity;
        }


        public Contact Update(Contact entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            var existingEntity = Repo.ContactRepo.GetById(entity.Id);
            if (existingEntity == null) throw new Exception("Data Not found");
            existingEntity.Name = entity.Name;
            existingEntity.PhoneNumber = entity.PhoneNumber;
            existingEntity.ContactTypeId = entity.ContactTypeId;
            existingEntity.ContactGroupId = entity.ContactGroupId;
            existingEntity.ModifiedDate = DateTime.Now;

            ApplyValidation(existingEntity);
            var duplicateEntity = Repo.ContactRepo.FindByNameAndNumberExceptMe(existingEntity.Id, existingEntity.Name, existingEntity.PhoneNumber);
            ApplyDuplicateBl(duplicateEntity);

            Repo.ContactRepo.Update(existingEntity);

            if (Repo.SaveChanges() <= 0) throw new Exception("Error In Update");

            return existingEntity;
        }

        public void DeleteById(long id)
        {
           
            if (id <= 0) throw new Exception("Id Should greater than zero");

            var existingEntity = Repo.ContactRepo.GetById(id);

            if (existingEntity == null) throw new Exception("Data Not found");

            Repo.ContactRepo.Remove(existingEntity);
            if (Repo.SaveChanges() <= 0) throw new Exception("Error In Delete");
        }

        public Contact FindById(long id)
        {
            var existingEntity = Repo.ContactRepo.GetById(id);
            if (existingEntity == null) throw new Exception("Data Not found");

            return existingEntity;
        }

        public IEnumerable<Contact> GetAsync()
        {
            return Repo.ContactRepo.GetAll();
        }

        public IEnumerable<Contact> GetFilterable(ContactFilterModel filter)
        {
            if (filter is null) throw new ArgumentNullException(nameof(filter));

            return Repo.ContactRepo.GetFilterable(filter);
        }
        public override void Dispose()
        {
            Repo.Dispose();
        }


        private void ApplyValidation(Contact entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            if (string.IsNullOrEmpty(entity.Name)) throw new Exception("Name is required");
            if (string.IsNullOrEmpty(entity.PhoneNumber)) throw new Exception("Phone is required");
            if (entity.ContactGroupId <= 0) throw new Exception("Group is required");
            if (entity.ContactTypeId <= 0) throw new Exception("Type is required");
        }

        private void ApplyDuplicateBl(Contact entity)
        {
            if (entity != null) throw new Exception("Data already Exist");
        }
    }
}
