using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.Core.Infra.Repos;

namespace CM.Repo
{
    public class Uow:IUow
    {
        private readonly CMDBContext _context;

        public Uow( CMDBContext context)
        {   
            _context = context;
            ContactRepo = new ContactRepo(_context);
            ContactTypeRepo = new ContactTypeRepo(_context);
            ContactGroupRepo = new ContactGroupRepo(_context);
        }
        
        public IContactRepo ContactRepo { get; }
        public IContactGroupRepo ContactGroupRepo { get; }
        public IContactTypeRepo ContactTypeRepo { get; }

        public  int Save()
        {
            return  _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
