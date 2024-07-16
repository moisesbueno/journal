using Journal.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Journal.Data.Maps
{
    public class JournalIndexationMap : IEntityTypeConfiguration<JournalIndexation>
    {
        public void Configure(EntityTypeBuilder<JournalIndexation> builder)
        {

            builder
                .HasNoKey()
                    .ToTable("journal_indexation");

            builder.HasIndex(e => e.Journalid, "journalid");

            builder.HasIndex(e => e.Journalindexationid, "journalindexationid");

            builder.Property(e => e.Journalid).HasColumnName("journalid");
            builder.Property(e => e.Journalindexationid)
                    .HasColumnType("int(11)")
                    .HasColumnName("journalindexationid");

            builder.HasOne(d => d.Journal).WithMany()
                    .HasForeignKey(d => d.Journalid)
                    .HasConstraintName("journal_indexation_ibfk_1");

            builder.HasOne(d => d.Journalindexation).WithMany()
                    .HasForeignKey(d => d.Journalindexationid)
                    .HasConstraintName("journal_indexation_ibfk_2");
        }
    }
}
