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
                entity.Active = true;
                entity.CreatedDate = DateTime.Now;
                _repo.ContactTypeRepo.Add(entity);
                _repo.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public void Update(ContactType entity)
        {
            var existingEntity = _repo.ContactTypeRepo.GetById(entity.Id);
            if (existingEntity != null)
            {
                existingEntity.Name = entity.Name;
                existingEntity.ModifiedDate = DateTime.Now;
                _repo.ContactTypeRepo.Update(existingEntity);
                _repo.Save();
            }
        }

        public void DeleteById(long id)
        {
            var entity = _repo.ContactTypeRepo.GetById(id);
            _repo.ContactTypeRepo.Remove(entity);
            _repo.Save();
        }

        public ContactType FindById(long id)
        {
            return _repo.ContactTypeRepo.GetById(id);
        }

        public IEnumerable<ContactType> Get()
        {
            return _repo.ContactTypeRepo.GetAll();
        }

        public IEnumerable<ContactType> GetFilterable(ContactTypeFilterModel filter)
        {
            return _repo.ContactTypeRepo.GetFilterable(filter);
        }

        public override void Dispose()
        {
            _repo.Dispose();
        }


    }
}
