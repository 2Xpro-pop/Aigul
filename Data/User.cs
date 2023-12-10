﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aigul.Data;
public class User
{
    public Guid Id
    {
        get; set;
    }

    public string Name
    {
        get; set;
    }

    public string Password
    {
        get; set;
    }

    public bool IsAdmin
    {
        get; set;
    }
}
