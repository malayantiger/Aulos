using Aulos.Core.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Infrastructure.Data
{
    public class TagLibTrackFileAdapter : ITrackFile
    {
        private readonly TagLib.Tag _trackMetadata;
        private readonly TagLib.Properties _trackProperties;

        private string _artistName;
        public string ArtistName
        {
            get { return _artistName ?? (_artistName = _trackMetadata.FirstPerformer); }
            set { _artistName = value; }
        }

        private string _albumTitle;
        public string AlbumTitle
        {
            get { return _albumTitle ?? (_albumTitle = _trackMetadata.Album); }
            set { _albumTitle = value; }
        }

        private int _releaseYear;
        public int ReleaseYear
        {
            get
            {
                if (_releaseYear == 0)
                    _releaseYear = (int)_trackMetadata.Year;

                return _releaseYear;
            }
            set { _releaseYear = value; }
        }

        private string _genre;
        public string Genre
        {
            get { return _genre ?? (_genre = _trackMetadata.FirstGenre); }
            set { _genre = value; }
        }

        private int _tracklistPosition;
        public int TracklistPosition 
        { 
            get 
            {
                if (_tracklistPosition == 0)
                    _tracklistPosition = (int)_trackMetadata.Track;

                return _tracklistPosition;
            }

            set { _tracklistPosition = value; } 
        }

        private string _title;
        public string Title 
        {
            get { return _title ?? (_title = _trackMetadata.Title); }
            set { _title = value; }
        }

        private string _duration;
        public string Duration 
        {
            get { return _duration ?? (_duration = _trackProperties.Duration.ToString(@"hh\:mm\:ss")); }
            set { _duration = value; } 
        }

        public string AlbumPath { get { return Path.GetDirectoryName(SourcePath); } }

        public string FileName { get { return Path.GetFileName(SourcePath); } }

        public string SourcePath { get; set; }

        public TagLibTrackFileAdapter()
        {

        }

        public TagLibTrackFileAdapter(TagLib.Tag trackMetadata, TagLib.Properties trackProperties, string sourcePath)
        {
            if (trackMetadata == null)
                throw new ArgumentNullException("Track metadata cannot be null.");

            if (trackProperties == null)
                throw new ArgumentNullException("Track properties cannot be null.");

            _trackMetadata = trackMetadata;
            _trackProperties = trackProperties;
            SourcePath = sourcePath;
        }
    }
}
