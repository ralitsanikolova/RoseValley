﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RegistrationResponceDTO
    {
        //Output
        public bool IsRegistrSuccessful   { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
