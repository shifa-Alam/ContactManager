using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Core.Models.ViewModels
{
    public class ContactViewModel : BaseModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int ContactTypeId { get; set; }
        public int ContactGroupId { get; set; }
        public string? ContactTypeName { get; set; }
        public string? ContactGroupName { get; set; }
    }
}
