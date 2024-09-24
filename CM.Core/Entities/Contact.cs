using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Core.Entities
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public long ContactTypeId { get; set; }
        public long ContactGroupId { get; set; }

        // Navigation property
        public ContactType ContactType { get; set; }
        public ContactGroup ContactGroup { get; set; }
    }
}
