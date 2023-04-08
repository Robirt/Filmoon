﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmoon.Requests
{
    public class UserSignUpRequest
    {
        public string UserName { get; set; }
        public string FirstName { get; set; } 

        public string LastName { get; set; } 

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

    }
}
