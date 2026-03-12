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
        PullFilterBox();
    }

    public void GetProduct()
    {
        var ctx = new SchetinkinContext();
        var agent = ctx.Agents.Include(x => x.Agenttype).ToList();


        if (Searchbox.Text != null)
        {
            agent = agent.Where(x => x.Login.ToLower().Contains(Searchbox.Text.ToLower())).ToList();
        }

        switch (SortBox.SelectedIndex)
        {
            case 0:
                agent = agent.OrderBy(x => x.Title).ToList();
                break;
            case 1:
                agent = agent.OrderByDescending(x => x.Title).ToList();
                break;
        }

        if (FilterBox.SelectedIndex !=-1 && FilterBox.SelectedIndex != 0)
        {
            agent = agent.Where(x => x.Agenttype.Title == FilterBox.SelectedItem!.ToString()).ToList();
        }

        ListAgent.ItemsSource = agent;


    }

    private void Searchbox_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e)
    {
        GetProduct();
    }

    private void SortBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        GetProduct();
    }

    public void PullFilterBox()
    {
        var ctx = new SchetinkinContext();
        var listType = ctx.Agenttypes.Select(x=>x.Title).ToList();

        listType.Add("Все");
        FilterBox.ItemsSource = listType.OrderByDescending(x=> x == "Все");
    }

}