using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace CM.Repo
{
    public class CMDBContext:DbContext
    {
        public CMDBContext(DbContextOptions options):base(options) { }
        //entities
        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<ContactGroup>? ContactGroups { get; set; }
        public DbSet<ContactType>? ContactTypes { get; set; }   
    }
}
