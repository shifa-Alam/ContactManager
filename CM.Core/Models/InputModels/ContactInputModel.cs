using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Core.Models.InputModels
{
    public class ContactInputModel: BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int ContactTypeId { get; set; }
        public int ContactGroupId { get; set; }
    }
}
