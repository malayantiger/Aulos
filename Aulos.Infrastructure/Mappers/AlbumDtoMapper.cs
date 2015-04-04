using Aulos.Core.Data;
using Aulos.Core.Domain.Entities;
using Aulos.Core.Domain.Factories;
using Aulos.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Aulos.Infrastructure.Mappers
{
    public static class AlbumDtoMapper
    {
        public static Album MapToEntity(this IAlbumDto dto)
        {
            var album = new Album
            {
                Artist = new Artist { Name = dto.ArtistName },
                Title = dto.Title,
                Genre = dto.Genre,
                SourcePath = dto.SourcePath
            };

            album.AddReleaseDate(dto.ReleaseYear);

            foreach (var track in dto.Tracklist)
            {
                album.AddTrack(track.MapToEntity());
            }

            return album;
        }

        public static AlbumJsonDto MapToJson(this Album album)
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

            jsonDto.Tracklist = album.Tracklist.Select(t => t.MapToJson());

            return jsonDto;
        }
    }
}
