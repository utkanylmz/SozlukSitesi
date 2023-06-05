using MediatR;
using SozlukWebSiteCommon.Events.EntryComment;
using SozlukWebSiteCommon.Infrastructure;
using SozlukWebSiteCommon.ViewModels.RequestModels;
using SozlukWebSiteCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukWebSitesiApi.Application.Features.Command.EntryComment.CreateVote
{
    public class CreateEntryCommentVoteCommandHandler :
    IRequestHandler<CreateEntryCommentVoteCommand, bool>
    {
        public async Task<bool> Handle(CreateEntryCommentVoteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.VoteExchangeName,
                exchangeType: SozlukConstants.DefaultExchangeType,
                queueName: SozlukConstants.CreateEntryCommentVoteQueueName,
                obj: new CreateEntryCommentVoteEvent()
                {
                    EntryCommentId = request.EntryCommentId,
                    VoteType = request.VoteType,
                    CreatedBy = request.CreatedBy
                });

            return await Task.FromResult(true);
        }
    }
}
