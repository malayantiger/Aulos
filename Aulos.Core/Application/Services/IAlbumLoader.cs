using Aulos.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Core.Application.Services
{
    public interface IAlbumLoaderService
    {
        Album Load(string albumPath);
        void Save(Album album);
    }
}
