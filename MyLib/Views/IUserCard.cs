﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Views
{
    public interface IUserCard
    {
        event Action<User> UserChange;
        void Show(User u);
    }
}
