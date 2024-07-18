using System;
using System.Collections.Generic;

namespace Journal.Data.Models;

public partial class JournalIndexation
{
    public Guid? Journalid { get; set; }

    public int? Journalindexationid { get; set; }

    public virtual Journal Journal { get; set; }

    public virtual DatabaseIndexation Journalindexation { get; set; }
}
