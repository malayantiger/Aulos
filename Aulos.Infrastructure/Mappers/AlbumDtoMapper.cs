using Aulos.Core.Data;
using Aulos.Core.Domain.Entities;
using Aulos.Core.Domain.Factories;
using Aulos.Core.Mappers;
using Aulos.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Aulos.Infrastructure.Mappers
{
    public class AlbumDtoMapper : IAlbumDtoMapper
    {
        private IAlbumFactory _albumFactory;
        private ITrackDtoMapper _trackFileMapper;

        public AlbumDtoMapper(IAlbumFactory albumFactory, ITrackDtoMapper trackFromFileMapper)
        {
            _albumFactory = albumFactory;
            _trackFileMapper = trackFromFileMapper;
        }

        public Album Map(IAlbumDto dto)
        {
            var entity = _albumFactory.Create();
            entity.Artist = new Artist() { Name = dto.ArtistName };
            entity.Title = dto.Title;
            entity.SourcePath = dto.SourcePath;

            foreach (var track in dto.Tracklist)
            {
                entity.AddTrack(_trackFileMapper.Map(track));
            }

            return entity;
        }

        public IAlbumDto MapToJson(Album album)
        {
            var jsonDto = new AlbumJsonDto 
            { 
                ArtistName = album.Artist.Name,
                Title = album.Title,
                SourcePath = album.SourcePath
            };

            jsonDto.Tracklist = album.Tracklist.Select(t => _trackFileMapper.MapToJson(t));

            return jsonDto;
        }
    }
}
