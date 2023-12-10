using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Aigul;
public class PageSelector : IViewLocator
{
    public IViewFor? ResolveView<T>(T? viewModel, string? contract = null)
    {
        if (viewModel is null)
        {
            return null;
        }

        var type = viewModel.GetType();
        var viewName = type.Name.Replace("ViewModel", "View");

        var viewType = Type.GetType($"Aigul.Views.{viewName}");

        if (viewType is null)
        {
            return null;
        }

        var view = Activator.CreateInstance(viewType);

        return (IViewFor?)view;
    }
}
