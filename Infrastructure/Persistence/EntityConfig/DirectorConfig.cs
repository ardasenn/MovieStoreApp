using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfig
{
    public class DirectorConfig : BaseConfig<Director>
    {
        public override void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.Property(a => a.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(a => a.LastName).IsRequired().HasMaxLength(100);
            base.Configure(builder);
        }
    }
}
