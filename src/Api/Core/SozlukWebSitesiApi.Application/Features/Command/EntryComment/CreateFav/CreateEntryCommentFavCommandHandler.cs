using MediatR;
using SozlukWebSiteCommon;
using SozlukWebSiteCommon.Events.EntryComment;
using SozlukWebSiteCommon.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukWebSitesiApi.Application.Features.Command.EntryComment.CreateFav
{
    public class CreateEntryCommentFavCommandHandler : IRequestHandler<CreateEntryCommentFavCommand, bool>
    {
        public async Task<bool> Handle(CreateEntryCommentFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.FavExchangeName,
                                               exchangeType: SozlukConstants.DefaultExchangeType,
                                               queueName: SozlukConstants.CreateEntryCommentFavQueueName,
                                               obj: new CreateEntryCommentFavEvent()
                                               {
                                                   CreatedBy = request.UserId,
                                                   EntryCommentId = request.EntryCommentId
                                               });
            return await Task.FromResult(true);
        }
    }
}
