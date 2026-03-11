using System;
using System.Collections.Generic;

namespace SchetinkinDemo06032026.Models;

public partial class Productsale
{
    public int Id { get; set; }

    public int? Agentid { get; set; }

    public int? Productid { get; set; }

    public DateTime? Saledate { get; set; }

    public int? Productcount { get; set; }

    public virtual Agent? Agent { get; set; }

    public virtual Product? Product { get; set; }
}
