﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Models
{
    public class UserLogin
    {
        public int UserId { set; get; }
        public string UserName { set; get; } = string.Empty;
        public string Password { set; get; } = string.Empty;
    }
}
