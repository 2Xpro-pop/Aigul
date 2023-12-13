using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Aigul.Data;
using Aigul.Dialogs;
using DynamicData;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Aigul.ViewModels;
public class RoomsViewModel : PageViewModel
{
    [Reactive]
    public ObservableCollection<Room> Rooms
    {
        get; set;
    }

    [Reactive]
    public Visibility Visibility
    {
        get; set;
    }

    public ICommand AddRoom
    {
        get;
    }

    public RoomsViewModel()
    {
        Rooms = [];

        if (App.User != null && App.User.IsAdmin)
        {
            Visibility = Visibility.Visible;
        }
        else
        {
            Visibility = Visibility.Hidden;
        }

        AddRoom = ReactiveCommand.Create(() =>
        {
            var vm = new AddRoomViewModel();
            var window = new AddRoomDialog
            {
                DataContext = vm
            };
            var result = window.ShowDialog();

            if (result ?? false)
            {
                using var db = new AppDbContext();

                var newRoom = new Room()
                {
                    Description = vm.Description,
                    Name = vm.Name,
                    PricePerNight = vm.PricePerNight
                };

                db.Add(newRoom);
                db.SaveChanges();

                Rooms.Add(newRoom);
            }
        });

        
    }
}
