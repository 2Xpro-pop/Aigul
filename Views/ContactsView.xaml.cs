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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Aigul.Data;
using Aigul.ViewModels;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;

namespace Aigul.Views;
/// <summary>
/// Логика взаимодействия для ContactsView.xaml
/// </summary>
public partial class ContactsView : ReactiveUserControl<ContactsViewModel>
{
    public ContactsView()
    {
        InitializeComponent();
        DataContext = ViewModel;
        this.WhenActivated(disposables =>
        {
            this.WhenAnyValue(x => x.ViewModel)
                .WhereNotNull()
                .Subscribe(async x =>
                {
                    DataContext = x;

                    await using var db = new AppDbContext();

                    x.Users = await db.Users.ToListAsync();
                });
        });
    }
}
