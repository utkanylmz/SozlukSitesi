using AutoMapper;
using SozlukWebSiteCommon.ViewModels.QueriesModels;
using SozlukWebSitesiApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukWebSitesiApi.Application.Interfaces.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LoginUserViewModel>()
                .ReverseMap();
        }
    }
}
