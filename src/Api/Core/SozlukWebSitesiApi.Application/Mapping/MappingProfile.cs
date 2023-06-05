using AutoMapper;
using SozlukWebSiteCommon.ViewModels.QueriesModels;
using SozlukWebSiteCommon.ViewModels.RequestModels;
using SozlukWebSitesiApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukWebSitesiApi.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LoginUserViewModel>()
                .ReverseMap();

            CreateMap<CreateUserCommand,User>()
                .ReverseMap();
            CreateMap<UpdateUserCommand,User>()
                .ReverseMap();

            CreateMap<CreateEntryCommand, Entry>()
          .ReverseMap();

            CreateMap<CreateEntryCommentCommand, EntryComment>()
                .ReverseMap();


        }
    }
}
