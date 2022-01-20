using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class UrlModelConfiguration : IEntityTypeConfiguration<UrlModel>
    {
        public void Configure(EntityTypeBuilder<UrlModel> builder)
        {
            builder.Property(o => o.LongName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(o => o.ShortName)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}

