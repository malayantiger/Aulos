﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Core.Domain.Factories
{
    public interface IFactory<TEntity>
    {
        TEntity Create();
    }
}
