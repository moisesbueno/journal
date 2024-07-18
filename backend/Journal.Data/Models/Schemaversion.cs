using System;
using System.Collections.Generic;

namespace Journal.Data.Models;

public partial class Schemaversion
{
    public int Schemaversionid { get; set; }

    public string Scriptname { get; set; }

    public DateTime Applied { get; set; }
}
