using Aulos.Core.Domain.Entities;
using Aulos.Core.Domain.Repositories;
using Aulos.Core.Infrastructure.Services;
using Aulos.Core.Mappers;
using Aulos.Infrastructure.Data;
using Aulos.Infrastructure.Factories;
using Aulos.Infrastructure.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aulos.Infrastructure.Repositories
{
    public class AlbumFileRepository : IAlbumRepository
    {
        private IFileProvider _fileProvider;
        private IAlbumDtoMapper _albumFileMapper;

        public AlbumFileRepository(IFileProvider fileProvider, IAlbumDtoMapper albumMapper)
        {
            _fileProvider = fileProvider;
            _albumFileMapper = albumMapper;
        }

        public Album GetByPath(string sourcePath)
        {
            var albumDto = _fileProvider.GetAlbum(sourcePath);

            return albumDto != null ? _albumFileMapper.Map(albumDto) : null;
        }

        public void Save(Album album)
        {
            var albumJson = (AlbumJsonDto)_albumFileMapper.MapToJson(album);
            var albumString = JsonConvert.SerializeObject(albumJson, Formatting.Indented);
            File.WriteAllText(album.Artist.Name + " - " + album.Title + ".txt", albumString);
        }

        public void Delete(Album aggregate)
        {
            throw new NotImplementedException();
        }


        public Album Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
