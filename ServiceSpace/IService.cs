﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSpace
{
    public interface IService
    {
        string Name { get; }

        void Start();

        void Stop();
    }
}
