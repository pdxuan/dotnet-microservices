﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingDomain.ValueObjects
{
    public record OrderName
    {
        public string Value { get;  }
    }
}