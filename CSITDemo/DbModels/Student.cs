﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSITDemo.DbModels
{
    public class Student : BaseDbModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Class { get; set; }
    }
}
