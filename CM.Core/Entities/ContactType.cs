using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Core.Entities
{
    public class ContactType : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        // Navigation property for relationships
        public ICollection<Contact> Contacts { get; set; }
    }
}
