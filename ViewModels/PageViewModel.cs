using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Aigul.ViewModels;
public class PageViewModel : BaseViewModel, IRoutableViewModel
{
    public string? UrlPathSegment
    {
        get;
    }

    [Reactive]
    public IScreen HostScreen
    {
        get; set;
    }
}
