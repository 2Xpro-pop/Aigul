using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
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
using DynamicData;
using ReactiveUI;

namespace Aigul.Views;
/// <summary>
/// Логика взаимодействия для RoomsView.xaml
/// </summary>
public partial class RoomsView : ReactiveUserControl<RoomsViewModel>
{
    public RoomsView()
    {
        InitializeComponent();

        this.WhenActivated(disposables =>
        {
            DataContext = ViewModel;

            this.WhenAnyValue(x => x.ViewModel)
                .Subscribe(x => DataContext = x)
                .DisposeWith(disposables);

            this.WhenAnyValue(x => x.DataContext)
                .Subscribe(x =>
                {
                    ViewModel = x as RoomsViewModel;

                })
                .DisposeWith(disposables);

            using var db = new AppDbContext();
            ViewModel.Rooms.Clear();
            ViewModel.Rooms.AddRange(db.Rooms.ToArray());
        });
    }

    private void ClickRoom(object sender, MouseButtonEventArgs e)
    {
        var border = (Border)sender;
        var room = (Room)border.DataContext;

        border.DataContext = new Room
        {
            Id = room.Id,
            Description = room.Description,
            Name = room.Name,
            PricePerNight = room.PricePerNight,
            IsLocked = !room.IsLocked,
        };

        room.IsLocked = !room.IsLocked;
        
        using var db = new AppDbContext();
        db.Update(room);
        db.SaveChanges();

    }
}
