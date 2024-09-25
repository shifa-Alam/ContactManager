using AutoMapper;
using CM.Core.Entities;
using CM.Core.Models.InputModels;
using CM.Core.Models.ViewModels;
using X.PagedList;


namespace CM.WebAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<ContactInputModel, Contact>();
            CreateMap<ContactTypeInputModel, ContactType>();
            CreateMap<ContactGroupInputModel, ContactGroup>();

            CreateMap<Contact, ContactViewModel>()
                .ForMember(dest => dest.ContactTypeName, m => m.MapFrom(src => src.ContactType.Name))
                .ForMember(dest => dest.ContactGroupName, m => m.MapFrom(src => src.ContactGroup.Name));

            CreateMap<ContactType, ContactTypeViewModel>();
            CreateMap<ContactGroup, ContactGroupViewModel>();

            CreateMap(typeof(PagedList<>), typeof(CustomPagedList<>)).ReverseMap().PreserveReferences();
            CreateMap(typeof(IPagedList<>), typeof(ICustomPagedList<>)).PreserveReferences().ConvertUsing(typeof(PagedListConverter<,>));

        }
    }
}
