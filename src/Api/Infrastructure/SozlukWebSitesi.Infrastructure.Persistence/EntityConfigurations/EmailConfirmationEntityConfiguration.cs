using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SozlukWebSitesiApi.Domain.Models;
using SozlukWebSitesi.Infrastructure.Persistence.Context;



namespace SozlukWebSitesi.Infrastructure.Persistence.EntityConfigurations
{
    public class EmailConfirmationEntityConfiguration : BaseEntityConfiguration<EMailConfirmation>
    {
        public override void Configure(EntityTypeBuilder<EMailConfirmation> builder)
        {
            base.Configure(builder);

            builder.ToTable("emailconfirmation", SozlukSitesiContext.DEFAULT_SCHEMA);
        }
    }
}
