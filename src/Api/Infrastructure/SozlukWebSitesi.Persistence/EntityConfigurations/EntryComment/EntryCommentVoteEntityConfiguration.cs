using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SozlukWebSitesiApi.Domain.Models;
using SozlukWebSitesi.Persistence.Context;

namespace SozlukWebSitesi.Persistence.EntityConfigurations.EntryComment
{
    public class EntryCommentVoteEntityConfiguration : BaseEntityConfiguration<EntryCommentVote>
    {
        public override void Configure(EntityTypeBuilder<EntryCommentVote> builder)
        {
            base.Configure(builder);

            builder.ToTable("entrycommentvote", SozlukSitesiContext.DEFAULT_SCHEMA);

            builder.HasOne(e => e.EntryComment).WithMany(e => e.EntryCommentVotes).HasForeignKey(e => e.EntryCommentId);
        }
    }
}
