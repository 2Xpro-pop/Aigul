using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Aigul.ViewModels;
public class MainWindowViewModel : BaseViewModel, IScreen
{
    public RoutingState Router
    {
        get;
    }

    public ReactiveCommand<IRoutableViewModel, Unit> GoTo
    {
        get;
    }

    public MainWindowViewModel()
    {
        Router = new RoutingState();

        GoTo = ReactiveCommand.Create((IRoutableViewModel vm) =>
        {
            Router.Navigate.Execute(vm).Subscribe();
        });
    }
}
