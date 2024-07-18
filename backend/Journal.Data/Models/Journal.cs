using System;
using System.Collections.Generic;

namespace Journal.Data.Models;

public partial class Journal
{
    
    public Guid Id { get; set; }

    public string Issn { get; set; }

    public string Name { get; set; }

    public int? Qualisid { get; set; }

    public string Aimscope { get; set; }

    public int? Formatid { get; set; }

    public bool? Apc { get; set; }

    public string Url { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Format Format { get; set; }

    public virtual Quali Qualis { get; set; }
}
