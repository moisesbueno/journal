using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Journal.Data.Maps
{
    public class JournalMap : IEntityTypeConfiguration<Journal.Data.Models.Journal>
    {
        public void Configure(EntityTypeBuilder<Models.Journal> builder)
        {

            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("journal");

            builder.HasIndex(e => e.Formatid, "formatid");

            builder.HasIndex(e => e.Qualisid, "qualisid");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Aimscope)
                    .HasMaxLength(255)
                    .HasColumnName("aimscope");
            builder.Property(e => e.Apc).HasColumnName("apc");
            builder.Property(e => e.Formatid)
                    .HasColumnType("int(11)")
                    .HasColumnName("formatid");
            builder.Property(e => e.Issn)
                    .HasMaxLength(20)
                    .HasColumnName("issn");
            builder.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            builder.Property(e => e.Qualisid)
                    .HasColumnType("int(11)")
                    .HasColumnName("qualisid");
            builder.Property(e => e.Url)
                    .HasMaxLength(200)
                    .HasColumnName("url");

            builder.HasOne(d => d.Format).WithMany(p => p.Journals)
                    .HasForeignKey(d => d.Formatid)
                    .HasConstraintName("journal_ibfk_2");

            builder.HasOne(d => d.Qualis).WithMany(p => p.Journals)
                    .HasForeignKey(d => d.Qualisid)
                    .HasConstraintName("journal_ibfk_1");

        }
    }
}
