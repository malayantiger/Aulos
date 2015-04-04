using Aulos.CatelUI.ViewModels;
using Aulos.Core.Data;
using Aulos.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.CatelUI.Mappers
{
    public static class ViewModelMapper
    {
        public static Album MapToEntity(this AlbumViewModel albumViewModel)
        {
            var album = new Album
            {
                Artist = new Artist { Name = albumViewModel.ArtistName },
                Title = albumViewModel.Title,
                Genre = albumViewModel.Genre,
                SourcePath = albumViewModel.SourcePath,
            };

            album.AddReleaseDate(albumViewModel.ReleaseYear);

            foreach (var track in albumViewModel.Tracklist)
            {
                album.AddTrack(track.MapToEntity());
            }

            return album;
        }

        public static AlbumViewModel MapToViewModel(this Album album)
        {
            var albumViewModel = new AlbumViewModel()
            {
                ArtistName = album.Artist.Name,
                Title = album.Title,
                ReleaseYear = album.ReleaseDate.Year,
                Genre = album.Genre,
                TotalTracksCount = album.TotalTracksCount,
                Duration = album.Duration.ToString(@"hh\:mm\:ss"),
                SourcePath = album.SourcePath
            };

            foreach (var track in album.Tracklist)
            {
                albumViewModel.Tracklist.Add(track.MapToViewModel());
            }

            return albumViewModel;
        }

        public static Track MapToEntity(this TrackViewModel trackViewModel)
        {
            var track = new Track
            {
                TracklistPosition = trackViewModel.TracklistPosition,
                Title = trackViewModel.Title,
                Duration = TimeSpan.Parse(trackViewModel.Duration)
            };

            return track;
        }

        public static TrackViewModel MapToViewModel(this Track track)
        {
            var trackViewModel = new TrackViewModel
            {
                TracklistPosition = track.TracklistPosition,
                Title = track.Title,
                Duration = track.Duration.ToString(@"hh\:mm\:ss")
            };

            return trackViewModel;
        }
    }
}
