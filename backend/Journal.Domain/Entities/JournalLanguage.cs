namespace Journal.Domain.Entities;

public partial class JournalLanguage : Entity
{
    public Guid? Journalid { get; set; }

    public int? Languageid { get; set; }

    public virtual Journal Journal { get; set; }

    public virtual Language Language { get; set; }
}