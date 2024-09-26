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
        private IUow _repo;

        public ContactGroupService(IUow repo)
        {
            _repo = repo;
        }

        public void Save(ContactGroup entity)
        {


            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));

                entity.Active = true;
                entity.CreatedDate = DateTime.Now;

                ApplyValidation(entity);
                _repo.ContactGroupRepo.Add(entity);
                _repo.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public void Update(ContactGroup entity)
        {
            try
            {
                if (entity is null) throw new ArgumentNullException(nameof(entity));
                var existingEntity = _repo.ContactGroupRepo.GetById(entity.Id);

                if (existingEntity != null)
                {
                    existingEntity.Name = entity.Name;

                    existingEntity.ModifiedDate = DateTime.Now;
                    ApplyValidation(existingEntity);
                    _repo.ContactGroupRepo.Update(existingEntity);
                    _repo.Save();
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

                var entity = _repo.ContactGroupRepo.GetById(id);
                _repo.ContactGroupRepo.Remove(entity);
                _repo.Save();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ContactGroup FindById(long id)
        {
            try
            {
                if (id <= 0) throw new Exception("Id Should greater than zero");
                return _repo.ContactGroupRepo.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IEnumerable<ContactGroup> Get()
        {
            try
            {
                return _repo.ContactGroupRepo.GetAll();
            }
            catch (Exception)
            {

                throw;
            }

        }


        public IEnumerable<ContactGroup> GetFilterable(ContactGroupFilterModel filter)
        {

            try
            {
                if (filter is null) throw new ArgumentNullException(nameof(filter));

                return _repo.ContactGroupRepo.GetFilterable(filter);
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void ApplyValidation(ContactGroup entity)
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
