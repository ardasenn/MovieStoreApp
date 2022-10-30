using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfig
{
    public class ActorConfig : BaseConfig<Actor>
    {
        public override void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(a => a.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(a => a.LastName).IsRequired().HasMaxLength(100);            
            builder.HasOne(a => a.Director).WithOne(a => a.Actor).HasForeignKey<Director>(a => a.Id);
            base.Configure(builder);
        }
    }
}
