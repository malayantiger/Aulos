using Aulos.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Infrastructure.Data
{
    class TagLibAlbumFileDtoAdapter : IAlbumDto
    {
        private TagLib.Tag _albumMetaData;

        public TagLibAlbumFileDtoAdapter(TagLib.Tag albumMetaData)
        {
            if (albumMetaData == null)
            {
                throw new ArgumentNullException("Album metadata cannot be null.");
            }

            _albumMetaData = albumMetaData;
        }

        private string _artistName;
        public string ArtistName 
        { 
            get { return _artistName ?? (_artistName = _albumMetaData.FirstPerformer); }
            set { _artistName = value; }
        }

        private string _title;
        public string Title 
        { 
            get { return _title ?? (_title = _albumMetaData.Album); }
            set { _title = value; }
        }

        public IEnumerable<ITrackDto> Tracklist { get; set; }

        private int _releaseYear;
        public int ReleaseYear
        {
            get
            {
                if (_releaseYear == 0) 
                    _releaseYear = (int)_albumMetaData.Year;

                return _releaseYear;
            }
            set { _releaseYear = value; }
        }

        private string _genre;
        public string Genre
        {
            get { return _genre ?? (_genre = _albumMetaData.FirstGenre); }
            set { _genre = value; }
        }

        public string Duration { get; set; }

        public string SourcePath { get; set; }

    }
}
