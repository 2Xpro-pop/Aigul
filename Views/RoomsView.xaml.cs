using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
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
using Microsoft.EntityFrameworkCore;
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
                .ObserveOn(RxApp.TaskpoolScheduler)
                .Subscribe(async x =>
                {

                    if(x is null)
                    {
                        return;
                    }

                    await using var db = new AppDbContext();
                    var rooms = await db.Rooms.ToArrayAsync();

                    x.Rooms = new(rooms);
                })
                .DisposeWith(disposables);

            this.WhenAnyValue(x => x.DataContext)
                .Subscribe(x =>
                {
                    if (DataContext is not RoomsViewModel roomsViewModel)
                    {
                        return;
                    }

                    ViewModel = roomsViewModel;
                })
                .DisposeWith(disposables);
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
