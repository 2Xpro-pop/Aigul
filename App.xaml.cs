using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Navigation;
using Aigul.Data;
using Aigul.ViewModels;
using Aigul.Views;
using Microsoft.EntityFrameworkCore;
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
        get; set;
    }

    public App()
    {
    }

    protected async override void OnStartup(StartupEventArgs e) 
    {
        base.OnStartup(e);

        await using var db = new AppDbContext();
        var user = await db.Users.ToListAsync();
        
        if (!await db.Users.AnyAsync(u => u.IsAdmin))
        {
            await db.Users.AddAsync(new User { IsAdmin = true, Name = "Aigul", Password = "1234d" });
        }

        if (!await db.Users.AnyAsync(u => !u.IsAdmin))
        {
            await db.Users.AddAsync(new User { Name = "AigulReception", Password = "fff" });
        }

        await db.SaveChangesAsync();
    }
}

