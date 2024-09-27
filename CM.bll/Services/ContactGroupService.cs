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
    public class ContactGroupService : BaseService, IContactGroupService
    {
        protected IUow Repo;

        public ContactGroupService(IUow repo)
        {
            Repo = repo;
        }

        public ContactGroup Save(ContactGroup entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            entity.Active = true;
            entity.CreatedDate = DateTime.Now;

            ApplyValidation(entity);
            var duplicateEntity = Repo.ContactGroupRepo.FindByName(entity.Name);
            ApplyDuplicateBl(duplicateEntity);

            Repo.ContactGroupRepo.Add(entity);
            if (Repo.SaveChanges() <= 0) throw new Exception("Error In save");
            return entity;
        }

        public ContactGroup Update(ContactGroup entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            var existingEntity = Repo.ContactGroupRepo.GetById(entity.Id);
            if (existingEntity == null) throw new Exception("Data Not found");

            existingEntity.Name = entity.Name;
            existingEntity.ModifiedDate = DateTime.Now;

            ApplyValidation(existingEntity);
            var duplicateEntity = Repo.ContactGroupRepo.FindByNameExceptMe(existingEntity.Id, existingEntity.Name);
            ApplyDuplicateBl(duplicateEntity);

            Repo.ContactGroupRepo.Update(existingEntity);

            if (Repo.SaveChanges() <= 0) throw new Exception("Error In Update");

            return existingEntity;

        }

        public void DeleteById(long id)
        {
            if (id <= 0) throw new Exception("Id Should greater than zero");

            var existingEntity = Repo.ContactGroupRepo.GetById(id);
            if (existingEntity == null) throw new Exception("Data Not found");

            Repo.ContactGroupRepo.Remove(existingEntity);

            if (Repo.SaveChanges() <= 0) throw new Exception("Error In Delete");
        }

        public ContactGroup FindById(long id)
        {
            if (id <= 0) throw new Exception("Id Should greater than zero");
            var existingEntity = Repo.ContactGroupRepo.GetById(id);

            if (existingEntity == null) throw new Exception("Data Not found");

            return existingEntity;
        }

        public IEnumerable<ContactGroup> Get()
        {
            return Repo.ContactGroupRepo.GetAll();
        }


        public IEnumerable<ContactGroup> GetFilterable(ContactGroupFilterModel filter)
        {
            if (filter is null) throw new ArgumentNullException(nameof(filter));

            return Repo.ContactGroupRepo.GetFilterable(filter);
        }

        public override void Dispose()
        {
            Repo.Dispose();
        }


        private void ApplyValidation(ContactGroup entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            if (string.IsNullOrEmpty(entity.Name)) throw new Exception("Name is required");

        }
        private void ApplyDuplicateBl(ContactGroup entity)
        {
            if (entity != null) throw new Exception("Data already Exist");
        }

    }
}
