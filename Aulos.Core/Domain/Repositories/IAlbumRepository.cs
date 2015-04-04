using Aulos.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Core.Domain.Repositories
{
    public interface IAlbumRepository
    {
        Album GetByPath(string sourcePath);
        Album Get(int id);
        void Save(Album album);
        void Delete(Album album);
    }
}
