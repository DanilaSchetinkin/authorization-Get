using System;
using System.Collections.Generic;

namespace SchetinkinDemo06032026.Models;

public partial class Materialcounthistory
{
    public int Id { get; set; }

    public int? Materialid { get; set; }

    public DateTime? Changedate { get; set; }

    public decimal? Countvalue { get; set; }

    public virtual Material? Material { get; set; }
}
