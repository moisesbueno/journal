namespace Journal.Data.Models;

public partial class Format
{
    public int Id { get; set; }

    public int? Maxpages { get; set; }

    public int? Maxwords { get; set; }

    public int? Space { get; set; }

    public int? Fontsize { get; set; }

    public virtual ICollection<Journal> Journals { get; set; } = new List<Journal>();
}
