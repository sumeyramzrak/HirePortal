using AutoMapper;
using Hireportal.Data.Request.Contracts;
using Hireportal.Entites.Main;
using Hireportal.Entites.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Mapper.Profiles
{
    internal class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<NewLookupRequestDto, LookUp>();
            CreateMap<NewLookupTypeRequestDto, LookUpType>();
            CreateMap<EditLookupRequestDto, LookUp>();
            CreateMap<EditLookupTypeRequestDto, LookUpType>();
            CreateMap<NewSystemParameterRequestDto, SystemParameter>();
            CreateMap<LookUp, LookUpDto>();
            CreateMap<LookUpType, LookupTypeDto>();
            CreateMap<SystemParameter, SystemParameterDto>();
        }
    }
}
