﻿using Core.Admin.Models;
using Core.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Admin.Interfaces
{
    public interface IUserStoreAdmin : IUserStore<ApplicationUser>, IStore<ApplicationUser, string>
    {

    }
}