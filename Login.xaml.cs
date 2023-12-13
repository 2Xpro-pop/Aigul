using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Aigul.Data;
using Microsoft.EntityFrameworkCore;

namespace Aigul;
/// <summary>
/// Логика взаимодействия для Login.xaml
/// </summary>
public partial class Login : Window
{
    public Login()
    {
        InitializeComponent();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        await using var db = new AppDbContext();

        var user = await db.Users.FirstOrDefaultAsync(u => u.Name == login.Text && u.Password == password.Text);

        if (user != null)
        {
            App.User = user;
            App.Current.MainWindow = new MainWindow();
            App.Current.MainWindow.Show();
            Close();
        }
        else
        {
            MessageBox.Show(this, "Неверный логин или пароль!");
        }
    }
}
