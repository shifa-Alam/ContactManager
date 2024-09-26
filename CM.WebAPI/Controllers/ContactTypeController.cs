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
    
    public class ContactTypeController : BaseController
    {
        
        private readonly IContactTypeService _contactTypeService;
        private readonly IMapper _mapper;

        public ContactTypeController( IContactTypeService ContactTypeService, IMapper mapper)
        {
           
            _contactTypeService = ContactTypeService;
            _mapper = mapper;

        }
        [HttpPost]
        [Route("SaveContactType")]
        public IActionResult SaveContactType(ContactTypeInputModel ContactTypeIn)
        {

            var mappedData = _mapper.Map<ContactType>(ContactTypeIn);

            _contactTypeService.Save(mappedData);
            return Ok();
        }
        [HttpPost]
        [Route("UpdateContactType")]
        public IActionResult UpdateContactType(ContactTypeInputModel ContactTypeIn)
        {

            var mappedData = _mapper.Map<ContactType>(ContactTypeIn);

            _contactTypeService.Update(mappedData);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteContactType")]
        public IActionResult DeleteContactType(long id)
        {
            _contactTypeService.DeleteById(id);

            return Ok();
        }


        [HttpGet]
        [Route("FindById")]
        public IActionResult FindById(long id)
        {

            var ContactType = _contactTypeService.FindById(id);

            var mappedData = _mapper.Map<ContactType, ContactTypeViewModel>(ContactType);
            if (mappedData == null) return NotFound();
            return Ok(mappedData);

        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {

            var all = _contactTypeService.Get();

            var result =_mapper.Map<IList<ContactType>, IList<ContactTypeViewModel>>((IList<ContactType>)all);

            return Ok(result);

        }
        [HttpGet]
        [Route("GetContactTypes")]
        public IActionResult GetContacts([FromQuery] ContactTypeFilterModel filter)
        {
            var customPagedList = _contactTypeService.GetFilterable(filter);

            var pagedList = _mapper.Map<IPagedList<ContactType>, ICustomPagedList<ContactTypeViewModel>>((IPagedList<ContactType>)customPagedList);

            return Ok(pagedList);

        }



        public override void Dispose()
        {
            _contactTypeService.Dispose();

        }
    }
}
