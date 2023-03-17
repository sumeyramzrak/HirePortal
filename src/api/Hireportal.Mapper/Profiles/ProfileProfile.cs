using AutoMapper;
using Hireportal.Data.Request.Contracts;
using Hireportal.Entites.CompanyManager;
using Hireportal.Entites.Profile;

namespace Hireportal.Mapper.Profiles
{
    internal class ProfileProfile : Profile
    {
        public ProfileProfile()
        {
            CreateMap<User, UserListDto>();
            CreateMap<RegisterUserRequestDto, User>();
            CreateMap<EditUserRequestDto, User>();
            CreateMap<NewCompanyRequestDto, Company>();
            CreateMap<NewUserRequestDto,User>();
            CreateMap<Company, CompanyDto>();
            CreateMap<Permission, PermissionDto>();
            CreateMap<NewPermissionRequestDto, Permission>();
            CreateMap<EditCompanyRequestDto, Company>();
            CreateMap<NewCompanyUserRequestDto, CompanyUser>();
            CreateMap<EditCompanyUserRequestDto, CompanyUser>();
            CreateMap<CompanyUser, CompanyUserDto>()
                .ForMember(m => m.CompanyId, f => f.MapFrom(s => s.Company.Id));

           

        }
    }
}
