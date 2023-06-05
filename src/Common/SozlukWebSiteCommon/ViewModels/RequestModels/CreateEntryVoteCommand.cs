using MediatR;

namespace SozlukWebSiteCommon.ViewModels.RequestModels
{
    public class CreateEntryVoteCommand : IRequest<bool>
    {
        public Guid EntryId { get; set; }
        public VoteType VoteType { get; set; }
        public Guid CreatedBy { get; set; }

        public CreateEntryVoteCommand()
        {
            
        }

        public CreateEntryVoteCommand(Guid entryCommentId, VoteType voteType, Guid createdBy)
        {
            EntryCommentId = entryCommentId;
            VoteType = voteType;
            CreatedBy = createdBy;
        }
    }
}
