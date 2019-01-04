using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Urzad.Data.Models;
using Urzad.Responses;

namespace Urzad.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Osoba, UserResponse>();
            CreateMap<UserResponse, Osoba>();
        }
    }
}
