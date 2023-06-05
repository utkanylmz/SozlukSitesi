using MediatR;
using SozlukWebSiteCommon;
using SozlukWebSiteCommon.Events.Entry;
using SozlukWebSiteCommon.Infrastructure;
using SozlukWebSiteCommon.ViewModels.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukWebSitesiApi.Application.Features.Command.Entry.CreateVote
{
    public class CreateEntryVoteCommandHandler : IRequestHandler<CreateEntryVoteCommand, bool>
    {
        public Task<bool> Handle(CreateEntryVoteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.VoteExchangeName,
                                                exchangeType: SozlukConstants.DefaultExchangeType,
                                                queueName: SozlukConstants.CreateEntryVoteQueueName,
                                                obj: new CreateEntryVoteEvent()
                                                {
                                                    CreatedBy = request.CreatedBy,
                                                    EntryId = request.EntryId,
                                                    VoteType = request.VoteType
                                                });
            return Task.FromResult(true);
        }
    }
}
