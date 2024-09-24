using CM.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using AutoMapper;
using CM.Core.Entities;
using CM.Core.Models.FilterModels;
using CM.Core.Models.InputModels;
using CM.Core.Models.ViewModels;
using CM.WebAPI.Helpers;
using X.PagedList;

namespace CM.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : BaseController
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("SaveContact")]
        public IActionResult SaveContact(ContactInputModel contactIn)
        {

            var mappedData = _mapper.Map<Contact>(contactIn);

            _contactService.Save(mappedData);
            return Ok();
        }
        [HttpPost]
        [Route("UpdateContact")]
        public IActionResult UpdateContact(ContactInputModel contactIn)
        {

            var mappedData = _mapper.Map<Contact>(contactIn);

            _contactService.Update(mappedData);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteContact")]
        public IActionResult DeleteContact(long id)
        {
            _contactService.DeleteById(id);

            return Ok();
        }



        [HttpGet]
        [Route("FindById")]
        public IActionResult FindById(long id)
        {

            var contact = _contactService.FindById(id);

            var mappedData = _mapper.Map<ContactViewModel>(contact);
            return Ok(mappedData);

        }

        [HttpGet]
        [Route("GetContacts")]
        public IActionResult GetContacts([FromQuery] ContactFilterModel filter)
        {
            var customPagedList = _contactService.GetFilterable(filter);

            var pagedList = _mapper.Map<IPagedList<Contact>, ICustomPagedList<ContactViewModel>>((IPagedList<Contact>)customPagedList);

            return Ok(pagedList);
           
        }

        public override void Dispose()
        {
            _contactService.Dispose();
            
        }
    }
}
