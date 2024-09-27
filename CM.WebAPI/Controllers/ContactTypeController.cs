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
    
    public class ContactTypeController : BaseController
    {

        private readonly IContactTypeService _contactTypeService;
        private readonly IMapper _mapper;

        public ContactTypeController(IContactTypeService contactTypeService, IMapper mapper)
        {

            _contactTypeService = contactTypeService;
            _mapper = mapper;

        }
        [HttpPost]
        [Route("SaveContactType")]
        public IActionResult SaveContactType(ContactTypeInputModel contactTypeIn)
        {
            try
            {
                if (contactTypeIn == null) throw new ArgumentNullException(nameof(contactTypeIn));

                var mappedData = _mapper.Map<ContactType>(contactTypeIn);

                var data = _contactTypeService.Save(mappedData);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Route("UpdateContactType")]
        public IActionResult UpdateContactType(ContactTypeInputModel contactTypeIn)
        {
            try
            {
                if (contactTypeIn == null) throw new ArgumentNullException(nameof(contactTypeIn));

                var mappedData = _mapper.Map<ContactType>(contactTypeIn);

                var data = _contactTypeService.Update(mappedData);
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteContactType")]
        public IActionResult DeleteContactType(long id)
        {
            try
            {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
                _contactTypeService.DeleteById(id);

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

                var ContactType = _contactTypeService.FindById(id);

                var mappedData = _mapper.Map<ContactType, ContactTypeViewModel>(ContactType);
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
                var all = _contactTypeService.Get();

                var result = _mapper.Map<IList<ContactType>, IList<ContactTypeViewModel>>((IList<ContactType>)all);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpGet]
        [Route("GetContactTypes")]
        public IActionResult GetContacts([FromQuery] ContactTypeFilterModel filter)
        {
            try
            {
                if (filter == null) throw new ArgumentNullException(nameof(filter));
                var customPagedList = _contactTypeService.GetFilterable(filter);

                var pagedList = _mapper.Map<IPagedList<ContactType>, ICustomPagedList<ContactTypeViewModel>>((IPagedList<ContactType>)customPagedList);

                return Ok(pagedList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }



        public override void Dispose()
        {
            _contactTypeService.Dispose();

        }
    }
}
