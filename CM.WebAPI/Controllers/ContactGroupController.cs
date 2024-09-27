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
    
    public class ContactGroupController : BaseController
    {

        private readonly IContactGroupService _contactGroupService;
        private readonly IMapper _mapper;

        public ContactGroupController(IContactGroupService contactGroupService, IMapper mapper)
        {

            _contactGroupService = contactGroupService;
            _mapper = mapper;

        }
        [HttpPost]
        [Route("SaveContactGroup")]
        public IActionResult SaveContactGroup(ContactGroupInputModel contactGroupIn)
        {

            try
            {
                if (contactGroupIn == null) throw new ArgumentNullException(nameof(contactGroupIn));

                var mappedData = _mapper.Map<ContactGroup>(contactGroupIn);

                var data = _contactGroupService.Save(mappedData);

                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        [Route("UpdateContactGroup")]
        public IActionResult UpdateContactGroup(ContactGroupInputModel contactGroupIn)
        {

            try
            {
                if (contactGroupIn == null) throw new ArgumentNullException(nameof(contactGroupIn));

                var mappedData = _mapper.Map<ContactGroup>(contactGroupIn);

                var data = _contactGroupService.Update(mappedData);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteContactGroup")]
        public IActionResult DeleteContactGroup(long id)
        {
            try
            {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
                _contactGroupService.DeleteById(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        [Route("FindById")]
        public IActionResult FindById(long id)
        {
            try
            {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
                var contactGroup = _contactGroupService.FindById(id);

                var mappedData = _mapper.Map<ContactGroup, ContactGroupViewModel>(contactGroup);

                return Ok(mappedData);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var all = _contactGroupService.Get();

                var result = _mapper.Map<IList<ContactGroup>, IList<ContactGroupViewModel>>((IList<ContactGroup>)all);

                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet]
        [Route("GetContactGroups")]
        public IActionResult GetContacts([FromQuery] ContactGroupFilterModel filter)
        {
            try
            {
                if (filter == null) throw new ArgumentNullException(nameof(filter));
                var customPagedList = _contactGroupService.GetFilterable(filter);

                var pagedList = _mapper.Map<IPagedList<ContactGroup>, ICustomPagedList<ContactGroupViewModel>>((IPagedList<ContactGroup>)customPagedList);

                return Ok(pagedList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        public override void Dispose()
        {
            _contactGroupService.Dispose();

        }
    }
}
