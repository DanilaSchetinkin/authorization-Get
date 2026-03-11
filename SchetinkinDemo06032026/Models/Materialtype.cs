using System;
using System.Collections.Generic;

namespace SchetinkinDemo06032026.Models;

public partial class Materialtype
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public decimal? Defectedpercent { get; set; }

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
