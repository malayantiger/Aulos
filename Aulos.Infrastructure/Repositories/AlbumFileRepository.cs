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
    public class AlbumFileRepository : IAlbumFileRepository
    {
        private IFileProvider _fileProvider;
        private IAlbumDtoMapper _albumFileMapper;

        public AlbumFileRepository(IFileProvider fileProvider, IAlbumDtoMapper albumFromFileMapper)
        {
            _fileProvider = fileProvider;
            _albumFileMapper = albumFromFileMapper;
        }

        public Album Get(string id)
        {
            throw new NotImplementedException();
        }

        public Album GetByPath(string sourcePath)
        {
            var albumDto = _fileProvider.GetAlbum(sourcePath);

            return albumDto != null ? _albumFileMapper.Map(albumDto) : null;
        }

        public void Save(Album aggregate)
        {
            var albumJson = (AlbumJsonDto)_albumFileMapper.MapToJson(aggregate);
            var albumString = JsonConvert.SerializeObject(albumJson);
            File.WriteAllText(aggregate.Artist.Name + " - " + aggregate.Title + ".txt", albumString);
        }

        public void Delete(Album aggregate)
        {
            throw new NotImplementedException();
        }
    }
}
