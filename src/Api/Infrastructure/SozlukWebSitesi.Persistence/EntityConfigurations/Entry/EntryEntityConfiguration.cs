using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SozlukWebSitesi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukWebSitesi.Persistence.EntityConfigurations.Entry
{
    public class EntryEntityConfiguration : BaseEntityConfiguration<SozlukWebSitesiApi.Domain.Models.Entry>
    {
        public override void Configure(EntityTypeBuilder<SozlukWebSitesiApi.Domain.Models.Entry> builder)
        {
            base.Configure(builder);

            builder.ToTable("entry", SozlukSitesiContext.DEFAULT_SCHEMA);

            builder.HasOne(e => e.CreatedBy).WithMany(e => e.Entries).HasForeignKey(e => e.CreatedById);
        }
    }
}
