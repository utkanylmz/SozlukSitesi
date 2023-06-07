using MediatR;
using SozlukWebSiteCommon.ViewModels.QueriesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukWebSitesiApi.Application.Features.Queries.GetEntries
{
    public class GetEntriesQuery:IRequest<List<GetEntriesViewModel>>
    {
        public bool TodaysEntries { get; set; }
        public int Count { get; set; } = 100;

    }
}
