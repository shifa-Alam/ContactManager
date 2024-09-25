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
    
    public class ContactController : BaseController
    {
        private readonly IContactService _contactService;
        private readonly IContactTypeService _contactTypeService;
        private readonly IContactGroupService _contactGroupService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IContactTypeService contactTypeService, IContactGroupService contactGroupService, IMapper mapper)
        {
            _contactService = contactService;
            _contactTypeService = contactTypeService;
            _contactGroupService = contactGroupService;
            _mapper = mapper;

        }
        [HttpPost]
        [Route("SaveContact")]
        public IActionResult SaveContact(ContactInputModel contactIn)
        {
            try
            {
                var mappedData = _mapper.Map<Contact>(contactIn);

                _contactService.Save(mappedData);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }
        [HttpPut]
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

            var mappedData = _mapper.Map<Contact, ContactViewModel>(contact);
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

        [HttpGet]
        [Route("DataSeed")]
        public IActionResult DataSeed()
        {

            for (int i = 1; i < 20; i++)
            {
                var contactGroup = new ContactGroup
                {
                    Name = "Group" + i,
                    CreatedDate = DateTime.Now

                };
                _contactGroupService.Save(contactGroup);



                var contactType = new ContactType
                {
                    Name = "Type" + i,
                    CreatedDate = DateTime.Now

                };
                _contactTypeService.Save(contactType);


            }

            for (int i = 1; i <= 100; i++)
            {
                var contact = new Contact
                {
                    Name = "Test" + i,
                    PhoneNumber = "01925564" + i,
                    CreatedDate = DateTime.Now,
                    ContactGroupId = 2,
                    ContactTypeId = 3

                };
                _contactService.Save(contact);
            }
            return Ok();

        }

        public override void Dispose()
        {
            _contactService.Dispose();

        }
    }
}
