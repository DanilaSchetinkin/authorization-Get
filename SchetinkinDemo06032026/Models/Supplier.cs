using System;
using System.Collections.Generic;

namespace SchetinkinDemo06032026.Models;

public partial class Supplier
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Inn { get; set; }

    public DateTime? Startdate { get; set; }

    public int? Qualityrating { get; set; }

    public string? Suppliertype { get; set; }

    public virtual ICollection<Materialsupplier> Materialsuppliers { get; set; } = new List<Materialsupplier>();
}
