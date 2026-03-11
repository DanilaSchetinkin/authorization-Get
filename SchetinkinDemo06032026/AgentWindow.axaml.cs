using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using SchetinkinDemo06032026.Models;
using System.Linq;

namespace SchetinkinDemo06032026;

public partial class AgentWindow : Window
{
    public AgentWindow()
    {
        InitializeComponent();
    }

    public AgentWindow(Agent agent)
    {
        InitializeComponent();
        GetProduct();
    }

    public void GetProduct()
    {
        var ctx = new SchetinkinContext();
        var agent = ctx.Agents.Include(x => x.Agenttype).ToList();
        ListAgent.ItemsSource = agent;
        
       
    }

}