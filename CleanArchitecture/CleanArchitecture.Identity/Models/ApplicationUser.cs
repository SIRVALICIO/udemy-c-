﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Identity.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Nombre { get; set; } = String.Empty;
        public string Apellidos { get; set; } = String.Empty;




    }
}
