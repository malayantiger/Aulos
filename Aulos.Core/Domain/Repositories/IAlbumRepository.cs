﻿using Aulos.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Core.Domain.Repositories
{
    public interface IAlbumRepository<in TKey> : IRepository<Album, TKey>
    {
        
    }
}
