﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal interface IFormatStrategy
    {
        void Format(List<Grade> grades);
    }
}