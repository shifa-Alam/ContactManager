using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Core.Models.InputModels
{
    public class ContactTypeInputModel : BaseModel
    {
        [Required(ErrorMessage = " Contact Type Name Is required")]
        public string Name { get; set; } = string.Empty;
    }
}
