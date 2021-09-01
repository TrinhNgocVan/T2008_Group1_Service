using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using user_service.Models;
using user_service.Dto;

namespace user_service.Mapper 
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            CreateMap<AppUser, AppUserDto>();
            CreateMap<AppUserDto, AppUser>();
            CreateMap<List<AppUser>, List<AppUserDto>>();
            CreateMap<user_service.Models.Profile, ProfileDto>();
            CreateMap<ProfileDto, user_service.Models.Profile>();

        }
    }
}
