using System;
using System.Collections.Generic;

namespace Journal.Data.Models;

public partial class Quali
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Journal> Journals { get; set; } = new List<Journal>();
}
