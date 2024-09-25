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
                entity.Active = true;
                entity.CreatedDate = DateTime.Now;
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
            var existingEntity = _repo.ContactGroupRepo.GetById(entity.Id);
            if (existingEntity != null)
            {
                existingEntity.Name = entity.Name;
           
                existingEntity.ModifiedDate = DateTime.Now;
                _repo.ContactGroupRepo.Update(existingEntity);
                _repo.Save();
            }
        }

        public void DeleteById(long id)
        {
            var entity = _repo.ContactGroupRepo.GetById(id);
            _repo.ContactGroupRepo.Remove(entity);
            _repo.Save();
        }

        public ContactGroup FindById(long id)
        {
            return _repo.ContactGroupRepo.GetById(id);
        }

        public IEnumerable<ContactGroup> Get()
        {
           return _repo.ContactGroupRepo.GetAll();
        }


        public IEnumerable<ContactGroup> GetFilterable(ContactGroupFilterModel filter)
        {
            return _repo.ContactGroupRepo.GetFilterable(filter);
        }
        public override void Dispose()
        {
            _repo.Dispose();
        }

       
    }
}
