using MediatR;
using SozlukWebSiteCommon.ViewModels.QueriesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukWebSitesiApi.Application.Features.Queries.GetEntryDetail
{
    public class GetEntryDetailQuery:IRequest<GetEntryDetailViewModel>
    {
        public GetEntryDetailQuery(Guid entryId, Guid? userId)
        {
            EntryId = entryId;
            UserId = userId;
        }

        public Guid EntryId { get; set; }
        public Guid? UserId { get; set; }
    }
}
