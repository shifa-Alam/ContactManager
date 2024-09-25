using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Core.Models.FilterModels
{
    public class ContactFilterModel : BaseFilter
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public int ContactTypeId { get; set; }
        public int ContactGroupId { get; set; } 
    }
}
