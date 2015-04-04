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
            var album = _albumFactory.Create();
            album.Artist = new Artist() { Name = dto.ArtistName };
            album.Title = dto.Title;
            album.Genre = dto.Genre;
            album.AddReleaseDate(dto.ReleaseYear);
            album.SourcePath = dto.SourcePath;

            foreach (var track in dto.Tracklist)
            {
                album.AddTrack(_trackFileMapper.Map(track));
            }

            return album;
        }

        public IAlbumDto MapToJson(Album album)
        {
            var jsonDto = new AlbumJsonDto 
            { 
                ArtistName = album.Artist.Name,
                Title = album.Title,
                ReleaseYear = album.ReleaseDate.Year,
                Genre = album.Genre,
                TotalTracksCount = album.TotalTracksCount,
                Duration = album.Duration.ToString(@"hh\:mm\:ss"),
                SourcePath = album.SourcePath
            };

            jsonDto.Tracklist = album.Tracklist.Select(t => _trackFileMapper.MapToJson(t));

            return jsonDto;
        }
    }
}
