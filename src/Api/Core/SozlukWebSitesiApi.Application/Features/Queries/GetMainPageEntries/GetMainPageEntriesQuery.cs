using AutoMapper;
using MediatR;
using SozlukWebSiteCommon.ViewModels.Page;
using SozlukWebSiteCommon.ViewModels.QueriesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukWebSitesiApi.Application.Features.Queries.GetMainPageEntries
{
    public class GetMainPageEntriesQuery:BasePagedQuery,IRequest<PagedViewModel<GetEntryDetailViewModel>>
    {
      

        public GetMainPageEntriesQuery(Guid ? userId,int page, int pageSize) : base(page, pageSize)
        {
            UserId = userId;
        }

        public Guid ? UserId { get; set; }
       
    }
}
