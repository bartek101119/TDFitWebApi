﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDFitWebApi.Models
{
    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string newPassword { get; set; }

    }
}
