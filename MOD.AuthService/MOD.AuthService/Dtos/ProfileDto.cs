﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.AuthService.Dtos
{
    public class ProfileDto
    {
        public string id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Skills { get; set; }

        public string Experience { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}
