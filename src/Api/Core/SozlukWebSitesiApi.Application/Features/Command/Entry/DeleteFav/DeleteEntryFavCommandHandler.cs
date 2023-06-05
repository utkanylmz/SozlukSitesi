using MediatR;
using SozlukWebSiteCommon;
using SozlukWebSiteCommon.Events.Entry;
using SozlukWebSiteCommon.Infrastructure;

namespace SozlukWebSitesiApi.Application.Features.Command.Entry.DeleteFav
{
    public class DeleteEntryFavCommandHandler : IRequestHandler<DeleteEntryFavCommand, bool>
    {
        public async Task<bool> Handle(DeleteEntryFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.FavExchangeName,
                                                exchangeType: SozlukConstants.DefaultExchangeType,
                                                queueName: SozlukConstants.DeleteEntryFavQueueName,
                                                obj: new DeleteEntryFavEvent()
                                                {
                                                    EntryId = request.EntryId,
                                                    CreatedBy = request.UserId
                                                });

            return await Task.FromResult(true);
        }
    }
}
