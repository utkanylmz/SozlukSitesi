namespace SozlukWebSiteCommon.Events.Entry
{
    public class DeleteEntryVoteEvent
    {
        public Guid EntryId { get; set; }

        public Guid CreatedBy { get; set; }
    }


}
