﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp_SocialNetwork.IService
{
    interface IServiceObj<T>
    {
        void SaveOrUpdate(T user);
        T GetUser(string userId);
        List<T> GetUsers();
        string Delete(string userId);

    }
}
