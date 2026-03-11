using Avalonia.Controls;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;
using SchetinkinDemo06032026.Models;
using System.Linq;

namespace SchetinkinDemo06032026
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SchetinkinContext ctx = new SchetinkinContext();
            if(LoginBox.Text !=null && PasswordBox.Text !=null)
            {
                var agent = ctx.Agents.FirstOrDefault(x=> x.Login == LoginBox.Text && x.Password == PasswordBox.Text);

                if (agent !=null)
                {
                    AgentWindow agentWindow = new AgentWindow(agent);
                    agentWindow.Show();
                    this.Close();
                }
                else
                {
                    var message = MessageBoxManager.GetMessageBoxStandard("Уведомление", 
                        "Не верный логин или пароль",
                        MsBox.Avalonia.Enums.ButtonEnum.Ok, 
                        MsBox.Avalonia.Enums.Icon.Error);
                    await message.ShowAsync();
                }
            }
        }
    }
}