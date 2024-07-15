using System;
using System.Collections.Generic;

namespace Journal.Data.Models;

public partial class JournalLanguage
{
    public Guid? Journalid { get; set; }

    public int? Languageid { get; set; }

    public virtual Journal? Journal { get; set; }

    public virtual Language? Language { get; set; }
}
