using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI.Fody.Helpers;

namespace Aigul.Data;
public class Room
{
    public Guid Id
    {
        get; set;
    } = Guid.NewGuid();

    public string Name
    {
        get; set;
    }
    public string Description
    {
        get; set;
    }
    public int PricePerNight
    {
        get; set;
    }
    public bool IsLocked
    {
        get; set;
    }
}
