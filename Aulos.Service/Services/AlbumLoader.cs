using Aulos.Core.Application.Services;
using Aulos.Core.Domain.Entities;
using Aulos.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Application.Services
{
    public class AlbumLoaderService : IAlbumLoaderService
    {
        private IAlbumFileRepository _albumFileRepository;

        public AlbumLoaderService(IAlbumFileRepository albumFileRepository)
        {
            _albumFileRepository = albumFileRepository;
        }

        public Album Load(string albumPath)
        {
            var album = _albumFileRepository.GetByPath(albumPath);

            return album;
        }
    }
}
