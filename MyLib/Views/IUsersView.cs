﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Views
{
    public interface IUsersView
    {
        void Show(List<User> users);

        int GetSelectedUserIndex();
    }
}
