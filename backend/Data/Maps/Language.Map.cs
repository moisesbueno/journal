using Journal.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Data.Maps
{
    public class LanguageMap : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("language");

            builder.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

            builder.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");
        }
    }
}
