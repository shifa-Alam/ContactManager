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
    public class ContactTypeService : BaseService, IContactTypeService
    {
        protected IUow Repo;

        public ContactTypeService(IUow repo)
        {
            Repo = repo;
        }

        public ContactType Save(ContactType entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            entity.Active = true;
            entity.CreatedDate = DateTime.Now;

            ApplyValidation(entity);
            var duplicateEntity = Repo.ContactTypeRepo.FindByName(entity.Name);
            ApplyDuplicateBl(duplicateEntity);

            Repo.ContactTypeRepo.Add(entity);
            if (Repo.SaveChanges() <= 0) throw new Exception("Error In save");
            return entity;
        }

        public ContactType Update(ContactType entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            var existingEntity = Repo.ContactTypeRepo.GetById(entity.Id);
            if (existingEntity == null) throw new Exception("Data Not found");

            existingEntity.Name = entity.Name;
            existingEntity.ModifiedDate = DateTime.Now;

            ApplyValidation(existingEntity);
            var duplicateEntity = Repo.ContactTypeRepo.FindByNameExceptMe(existingEntity.Id, existingEntity.Name);
            ApplyDuplicateBl(duplicateEntity);

            Repo.ContactTypeRepo.Update(existingEntity);

            if (Repo.SaveChanges() <= 0) throw new Exception("Error In Update");

            return existingEntity;

        }

        public void DeleteById(long id)
        {
            if (id <= 0) throw new Exception("Id Should greater than zero");

            var existingEntity = Repo.ContactTypeRepo.GetById(id);
            if (existingEntity == null) throw new Exception("Data Not found");

            Repo.ContactTypeRepo.Remove(existingEntity);

            if (Repo.SaveChanges() <= 0) throw new Exception("Error In Delete");
        }

        public ContactType FindById(long id)
        {
            if (id <= 0) throw new Exception("Id Should greater than zero");
            var existingEntity = Repo.ContactTypeRepo.GetById(id);

            if (existingEntity == null) throw new Exception("Data Not found");

            return existingEntity;
        }

        public IEnumerable<ContactType> Get()
        {
            return Repo.ContactTypeRepo.GetAll();
        }


        public IEnumerable<ContactType> GetFilterable(ContactTypeFilterModel filter)
        {
            if (filter is null) throw new ArgumentNullException(nameof(filter));

            return Repo.ContactTypeRepo.GetFilterable(filter);
        }

        public override void Dispose()
        {
            Repo.Dispose();
        }


        private void ApplyValidation(ContactType entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            if (string.IsNullOrEmpty(entity.Name)) throw new Exception("Name is required");

        }
        private void ApplyDuplicateBl(ContactType entity)
        {
            if (entity != null) throw new Exception("Data already Exist");
        }

    }
}
