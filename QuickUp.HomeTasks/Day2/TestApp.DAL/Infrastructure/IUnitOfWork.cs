﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.DAL.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
