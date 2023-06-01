using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SozlukWebSitesi.Persistence.Context;
using SozlukWebSitesiApi.Domain.Models;

namespace SozlukWebSitesi.Persistence.EntityConfigurations.Entry
{
    public class EntryFavoriteEntityConfiguration : BaseEntityConfiguration<EntryFavorite>
    {
        public override void Configure(EntityTypeBuilder<EntryFavorite> builder)
        {
            base.Configure(builder);

            builder.ToTable("entryfavorite", SozlukSitesiContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.Entry).WithMany(i => i.EntryFavorites).HasForeignKey(i => i.EntryId);

            builder.HasOne(e => e.CreatedUser).WithMany(e => e.EntryFavorites).HasForeignKey(e => e.CreatedById).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
