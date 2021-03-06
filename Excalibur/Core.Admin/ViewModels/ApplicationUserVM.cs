﻿using Core.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Admin.ViewModels
{
    public class ApplicationUserVM
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string HashPwd { get; set; }

        public PersonInfo PersonInfo { get; set; }
    }
}
