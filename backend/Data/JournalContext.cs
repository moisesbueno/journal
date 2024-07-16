using Journal.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
