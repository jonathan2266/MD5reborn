﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD5reborn.hash
{
    public interface IHash
    {
        string Hash(string text);
    }
}