using System.Configuration;
using System.Data;
using System.Windows;
using Aigul.Data;
using Aigul.ViewModels;
using Aigul.Views;
using ReactiveUI;
using Splat;

namespace Aigul;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static User User
    {
        get; private set;
    } 

    public App()
    {
        User = new User()
        {
            IsAdmin = true,
        };
    }
}

