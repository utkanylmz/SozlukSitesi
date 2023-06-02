using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SozlukWebSitesi.Infrastructure.Persistence.Context;
using SozlukWebSitesi.Infrastructure.Persistence.EntityConfigurations;
using SozlukWebSitesiApi.Domain.Models;

namespace SozlukSitesi.Infrastructure.Persistence.EntityConfigurations.Entry
{
    public class EntryVoteEntityConfiguration : BaseEntityConfiguration<EntryVote>
    {
        public override void Configure(EntityTypeBuilder<EntryVote> builder)
        {
            base.Configure(builder);

            builder.ToTable("entryvote", SozlukSitesiContext.DEFAULT_SCHEMA);

            builder.HasOne(e => e.Entry).WithMany(e => e.EntryVotes).HasForeignKey(e => e.EntryId);
        }
    }
}
