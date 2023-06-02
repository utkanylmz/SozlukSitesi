using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukWebSitesi.Infrastructure.Persistence.Context;
using SozlukSitesi.Infrastructure.Persistence.EntityConfigurations;

namespace SozlukWebSitesi.Infrastructure.Persistence.EntityConfigurations.EntryComment
{
    internal class EntryCommentEntityConfiguration : BaseEntityConfiguration<SozlukWebSitesiApi.Domain.Models.EntryComment>
    {
        public override void Configure(EntityTypeBuilder<SozlukWebSitesiApi.Domain.Models.EntryComment> builder)
        {
            base.Configure(builder);

            builder.ToTable("entrycomment", SozlukSitesiContext.DEFAULT_SCHEMA);

            builder.HasOne(e => e.CreatedBy)
                .WithMany(e => e.EntryComments)
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Entry).WithMany(e => e.EntryComments).HasForeignKey(e => e.EntryId);
        }
    }
}
