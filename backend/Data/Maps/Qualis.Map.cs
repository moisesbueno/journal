using Journal.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Journal.Data.Maps
{
    public class QualisMap : IEntityTypeConfiguration<Quali>
    {
        public void Configure(EntityTypeBuilder<Quali> builder)
        {

            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("qualis");

            builder.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");
            builder.Property(e => e.Description)
                    .HasMaxLength(10)
                    .HasColumnName("description");
        }
    }
}
