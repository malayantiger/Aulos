using Aulos.Core.Domain.Entities;
using Aulos.Core.Domain.Repositories;
using Aulos.Core.Infrastructure.Services;
using Aulos.Infrastructure.Data;
using Aulos.Infrastructure.Factories;
using Aulos.Infrastructure.Mappers;
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

        public AlbumFileRepository(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public Album GetByPath(string sourcePath)
        {
            var albumTracksCollection = _fileProvider.GetAlbum(sourcePath);

            return albumTracksCollection != null ? albumTracksCollection.ToList().MapToEntity() : null;
        }

        public void Save(Album album)
        {
            //var albumJson = album.MapToJson();
            //var albumString = JsonConvert.SerializeObject(albumJson, Formatting.Indented);
            //File.WriteAllText(album.Artist.Name + " - " + album.Title + ".txt", albumString);
            _fileProvider.SaveAlbum(album.MapToTrackFiles());
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
