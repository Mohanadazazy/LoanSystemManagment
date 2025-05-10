using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;
using Shared;

namespace Services.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UsersResultDto>()
                .ForMember(d => d.UserId, o => o.MapFrom(l => l.Id))
                .ReverseMap();
        }
    }
}
