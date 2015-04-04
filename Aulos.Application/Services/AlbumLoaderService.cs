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
        private IAlbumRepository _albumFileRepository;

        public AlbumLoaderService(IAlbumRepository albumFileRepository)
        {
            _albumFileRepository = albumFileRepository;
        }

        public Album Load(string albumPath)
        {
            var album = _albumFileRepository.GetByPath(albumPath);

            return album;
        }

        public void Save(Album album)
        {
            _albumFileRepository.Save(album);
        }
    }
}
