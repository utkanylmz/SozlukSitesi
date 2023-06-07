using MediatR;
using SozlukWebSiteCommon.ViewModels.Page;
using SozlukWebSiteCommon.ViewModels.QueriesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukWebSitesiApi.Application.Features.Queries.GetEntryComments
{
    public class GetEntryCommentsQuery : BasePagedQuery,IRequest<PagedViewModel<GetEntriesCommentsViewModel>>
    {
        public GetEntryCommentsQuery(Guid entryId, Guid? userId,int page, int pageSize) : base(page, pageSize)
        {
            EntryId = entryId;
            UserId = userId;
        }
        public Guid EntryId { get; set; }
        public Guid? UserId { get; set; }
    }
}
