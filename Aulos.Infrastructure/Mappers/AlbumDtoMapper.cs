using Aulos.Core.Domain.Entities;
using Aulos.Core.Domain.Factories;
using Aulos.Core.Infrastructure.Data;
using Aulos.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Aulos.Infrastructure.Mappers
{
    public static class AlbumDtoMapper
    {
        public static Album MapToEntity(this IList<ITrackFile> dto)
        {
            var firstTrack = dto.FirstOrDefault();
            var album = new Album
            {
                Artist = new Artist { Name = firstTrack.ArtistName },
                Title = firstTrack.AlbumTitle,
                Genre = firstTrack.Genre,
                SourcePath = firstTrack.AlbumPath
            };

            album.AddReleaseDate(firstTrack.ReleaseYear);

            foreach (var track in dto)
            {
                album.AddTrack(track.MapToEntity());
            }

            return album;
        }

        public static IEnumerable<ITrackFile> MapToTrackFiles(this Album album)
        {
            var trackFiles = new List<ITrackFile>();

            foreach (var track in album.Tracklist)
            {
                var trackFile = new TagLibTrackFileAdapter
                {
                    ArtistName = album.Artist.Name,
                    AlbumTitle = album.Title,
                    TracklistPosition = track.TracklistPosition,
                    Title = track.Title,
                    Genre = album.Genre,
                    Duration = track.Duration.ToString(@"hh\:mm\:ss"),
                    ReleaseYear = album.ReleaseDate.Year,
                    SourcePath = album.SourcePath + "\\" + track.FileName
                };

                trackFiles.Add(trackFile);
            }

            return trackFiles;
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
