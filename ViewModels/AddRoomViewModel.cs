using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI.Fody.Helpers;

namespace Aigul.ViewModels;
public class AddRoomViewModel : BaseViewModel
{
    [Reactive]
    public string Name
    {
        get; set;
    }

    [Reactive]
    public string Description
    {
        get; set;
    }

    [Reactive]
    public int PricePerNight
    {
        get; set;
    }
}
