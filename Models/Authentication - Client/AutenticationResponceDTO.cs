﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AutenticationResponceDTO
    {
        //Output
        public bool IsAuthSuccessful { get; set; }
        public string Error { get; set; }

        public string Token { get; set; }
        public UserDTO UserDTO { get; set; }
    }
}
