﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VCI_API.Models.DTO.Request
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}