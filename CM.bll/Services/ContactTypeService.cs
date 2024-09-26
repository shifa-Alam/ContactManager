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
        private IUow _repo;

        public ContactTypeService(IUow repo)
        {
            _repo = repo;
        }

        public void Save(ContactType entity)
        {

            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));
                entity.Active = true;
                entity.CreatedDate = DateTime.Now;

                ApplyValidation(entity);
                _repo.ContactTypeRepo.Add(entity);
                _repo.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Update(ContactType entity)
        {
            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));
                var existingEntity = _repo.ContactTypeRepo.GetById(entity.Id);
                if (existingEntity != null)
                {
                    existingEntity.Name = entity.Name;
                    existingEntity.ModifiedDate = DateTime.Now;

                    ApplyValidation(existingEntity);

                    _repo.ContactTypeRepo.Update(existingEntity);
                    _repo.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void DeleteById(long id)
        {
            try
            {
                if (id <= 0) throw new Exception("Id Should greater than zero");
                var entity = _repo.ContactTypeRepo.GetById(id);
                _repo.ContactTypeRepo.Remove(entity);
                _repo.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ContactType FindById(long id)
        {
            try
            {
                if (id <= 0) throw new Exception("Id Should greater than zero");
                return _repo.ContactTypeRepo.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IEnumerable<ContactType> Get()
        {
            try
            {
                return _repo.ContactTypeRepo.GetAll();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IEnumerable<ContactType> GetFilterable(ContactTypeFilterModel filter)
        {
            try
            {
                if (filter is null) throw new ArgumentNullException(nameof(filter));
                return _repo.ContactTypeRepo.GetFilterable(filter);
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void ApplyValidation(ContactType entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            if (string.IsNullOrEmpty(entity.Name)) throw new Exception("Name is required");

        }

        public override void Dispose()
        {
            _repo.Dispose();
        }


    }
}
