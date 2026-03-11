using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;

namespace SchetinkinDemo06032026.Models;

public partial class Agent
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int Agenttypeid { get; set; }

    public string Address { get; set; } = null!;

    public string? Inn { get; set; }

    public string? Kpp { get; set; }

    public string? Direcorname { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Logo { get; set; }

    public Bitmap? ImagePath
    {
        get
        {
            return new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "/" + Logo);
        }
    }

    public int? Prioriry { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Agentpriorityhistory> Agentpriorityhistories { get; set; } = new List<Agentpriorityhistory>();

    public virtual Agenttype Agenttype { get; set; } = null!;

    public virtual ICollection<Productsale> Productsales { get; set; } = new List<Productsale>();

    public virtual ICollection<Shop> Shops { get; set; } = new List<Shop>();
}
