using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using SchoolOfLanguages.Models;

namespace SchoolOfLanguages;

public partial class Redact : Window
{
    private Client SaveClient;
    public Redact()
    {
        InitializeComponent();
        SaveClient = new Client();
    }
    public Redact(Client client)
    {
        InitializeComponent();
        SaveClient = client;
        RedactModel.DataContext = SaveClient;
    }
    public void Save_Button(object sender, RoutedEventArgs e)
    {
        var client = Helper.DataBase.Clients.Find(SaveClient.Id);
        if (client != null)
        {
            Helper.DataBase.Entry(client).CurrentValues.SetValues(SaveClient);
            Helper.DataBase.SaveChanges();
        }
        else
        {
            Helper.DataBase.Clients.Add(SaveClient);
            Helper.DataBase.SaveChanges();
        }
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }

    public void Back_Button(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }
}