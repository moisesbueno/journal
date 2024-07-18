using Journal.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Journal.Data.Maps
{
    public class FormatMap : IEntityTypeConfiguration<Format>
    {
        public void Configure(EntityTypeBuilder<Format> builder)
        {

            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("format");

            builder.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");
            builder.Property(e => e.Fontsize)
                    .HasColumnType("int(11)")
                    .HasColumnName("fontsize");
            builder.Property(e => e.Maxpages)
                    .HasColumnType("int(11)")
                    .HasColumnName("maxpages");
            builder.Property(e => e.Maxwords)
                    .HasColumnType("int(11)")
                    .HasColumnName("maxwords");
            builder.Property(e => e.Space)
                    .HasColumnType("int(11)")
                    .HasColumnName("space");

        }
    }
}
