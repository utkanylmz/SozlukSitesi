using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SozlukWebSitesiApi.Domain.Models;
using SozlukWebSitesi.Persistence.Context;

namespace SozlukWebSitesi.Persistence.EntityConfigurations.EntryComment
{
    public class EntryCommentFavoriteEntityConfiguration : BaseEntityConfiguration<EntryCommentFavorite>
    {
        public override void Configure(EntityTypeBuilder<EntryCommentFavorite> builder)
        {
            base.Configure(builder);

            builder.ToTable("entrycommentfavorite", SozlukSitesiContext.DEFAULT_SCHEMA);

            builder.HasOne(e => e.EntryComment).WithMany(e => e.EntryCommentFavorites).HasForeignKey(e => e.EntryCommentId);

            builder.HasOne(e => e.CreatedUser).WithMany(e => e.EntryCommentFavorites).HasForeignKey(e => e.CreatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
