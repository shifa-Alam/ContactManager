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
using CM.bll.Services;

namespace CM.WebAPI.Controllers
{
    [ApiController]
    
    public class ContactGroupController : BaseController
    {
        
        private readonly IContactGroupService _contactGroupService;
        private readonly IMapper _mapper;

        public ContactGroupController( IContactGroupService ContactGroupService, IMapper mapper)
        {
           
            _contactGroupService = ContactGroupService;
            _mapper = mapper;

        }
        [HttpPost]
        [Route("SaveContactGroup")]
        public IActionResult SaveContactGroup(ContactGroupInputModel ContactGroupIn)
        {

            var mappedData = _mapper.Map<ContactGroup>(ContactGroupIn);

            _contactGroupService.Save(mappedData);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateContactGroup")]
        public IActionResult UpdateContactGroup(ContactGroupInputModel ContactGroupIn)
        {

            var mappedData = _mapper.Map<ContactGroup>(ContactGroupIn);

            _contactGroupService.Update(mappedData);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteContactGroup")]
        public IActionResult DeleteContactGroup(long id)
        {
            _contactGroupService.DeleteById(id);

            return Ok();
        }


        [HttpGet]
        [Route("FindById")]
        public IActionResult FindById(long id)
        {

            var ContactGroup = _contactGroupService.FindById(id);

            var mappedData = _mapper.Map<ContactGroup, ContactGroupViewModel>(ContactGroup);
            return Ok(mappedData);

        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {

            var all = _contactGroupService.Get();

            var result = _mapper.Map<IList<ContactGroup>, IList<ContactGroupViewModel>>((IList<ContactGroup>)all);

            return Ok(result);

           

        }

        [HttpGet]
        [Route("GetContactGroups")]
        public IActionResult GetContacts([FromQuery] ContactGroupFilterModel filter)
        {
            var customPagedList = _contactGroupService.GetFilterable(filter);

            var pagedList = _mapper.Map<IPagedList<ContactGroup>, ICustomPagedList<ContactGroupViewModel>>((IPagedList<ContactGroup>)customPagedList);

            return Ok(pagedList);

        }


        public override void Dispose()
        {
            _contactGroupService.Dispose();

        }
    }
}
