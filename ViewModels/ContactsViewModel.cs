using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aigul.Data;
using Microsoft.EntityFrameworkCore;
using ReactiveUI.Fody.Helpers;

namespace Aigul.ViewModels;
public class ContactsViewModel : PageViewModel
{
    [Reactive]
    public IEnumerable<User> Users
    {
        get; set;
    }

    public ContactsViewModel()
    {
    }
}
