using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SozlukWebSitesiApi.Domain.Models;
using SozlukWebSitesi.Persistence.Context;

namespace SozlukWebSitesi.Persistence.EntityConfigurations
{
    public class UserEntityConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("user", SozlukSitesiContext.DEFAULT_SCHEMA);
        }
    }
}
