using Journal.Data.Maps;
using Journal.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Journal.Data;

public partial class JournalContext : DbContext
{
    public JournalContext()
    {
    }

    public JournalContext(DbContextOptions<JournalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DatabaseIndexation> DatabaseIndexations { get; set; }

    public virtual DbSet<Format> Formats { get; set; }

    public virtual DbSet<Importacao> Importacaos { get; set; }

    public virtual DbSet<Models.Journal> Journals { get; set; }

    public virtual DbSet<JournalIndexation> JournalIndexations { get; set; }

    public virtual DbSet<JournalLanguage> JournalLanguages { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Quali> Qualis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_uca1400_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.ApplyConfiguration(new DatabaseIndexationMap());

        modelBuilder.Entity<Format>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("format");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Fontsize)
                .HasColumnType("int(11)")
                .HasColumnName("fontsize");
            entity.Property(e => e.Maxpages)
                .HasColumnType("int(11)")
                .HasColumnName("maxpages");
            entity.Property(e => e.Maxwords)
                .HasColumnType("int(11)")
                .HasColumnName("maxwords");
            entity.Property(e => e.Space)
                .HasColumnType("int(11)")
                .HasColumnName("space");
        });

        modelBuilder.Entity<Importacao>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("importacao");

            entity.Property(e => e.Issn)
                .HasMaxLength(20)
                .HasColumnName("issn");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Qualis2019)
                .HasMaxLength(10)
                .HasColumnName("qualis_2019");
        });

        modelBuilder.Entity<Models.Journal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("journal");

            entity.HasIndex(e => e.Formatid, "formatid");

            entity.HasIndex(e => e.Qualisid, "qualisid");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aimscope)
                .HasMaxLength(255)
                .HasColumnName("aimscope");
            entity.Property(e => e.Apc).HasColumnName("apc");
            entity.Property(e => e.Formatid)
                .HasColumnType("int(11)")
                .HasColumnName("formatid");
            entity.Property(e => e.Issn)
                .HasMaxLength(20)
                .HasColumnName("issn");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Qualisid)
                .HasColumnType("int(11)")
                .HasColumnName("qualisid");
            entity.Property(e => e.Url)
                .HasMaxLength(200)
                .HasColumnName("url");

            entity.HasOne(d => d.Format).WithMany(p => p.Journals)
                .HasForeignKey(d => d.Formatid)
                .HasConstraintName("journal_ibfk_2");

            entity.HasOne(d => d.Qualis).WithMany(p => p.Journals)
                .HasForeignKey(d => d.Qualisid)
                .HasConstraintName("journal_ibfk_1");
        });

        modelBuilder.Entity<JournalIndexation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("journal_indexation");

            entity.HasIndex(e => e.Journalid, "journalid");

            entity.HasIndex(e => e.Journalindexationid, "journalindexationid");

            entity.Property(e => e.Journalid).HasColumnName("journalid");
            entity.Property(e => e.Journalindexationid)
                .HasColumnType("int(11)")
                .HasColumnName("journalindexationid");

            entity.HasOne(d => d.Journal).WithMany()
                .HasForeignKey(d => d.Journalid)
                .HasConstraintName("journal_indexation_ibfk_1");

            entity.HasOne(d => d.Journalindexation).WithMany()
                .HasForeignKey(d => d.Journalindexationid)
                .HasConstraintName("journal_indexation_ibfk_2");
        });

        modelBuilder.Entity<JournalLanguage>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("journal_language");

            entity.HasIndex(e => e.Journalid, "journalid");

            entity.HasIndex(e => e.Languageid, "languageid");

            entity.Property(e => e.Journalid).HasColumnName("journalid");
            entity.Property(e => e.Languageid)
                .HasColumnType("int(11)")
                .HasColumnName("languageid");

            entity.HasOne(d => d.Journal).WithMany()
                .HasForeignKey(d => d.Journalid)
                .HasConstraintName("journal_language_ibfk_1");

            entity.HasOne(d => d.Language).WithMany()
                .HasForeignKey(d => d.Languageid)
                .HasConstraintName("journal_language_ibfk_2");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("language");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Quali>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("qualis");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(10)
                .HasColumnName("description");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
