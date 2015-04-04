using Aulos.Core.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Infrastructure.Services
{
    public static class TagLibFileEditor
    {
        public static TagLib.Tag Edit(this TagLib.Tag tag, ITrackFile trackFile)
        {
            tag.Performers = null;
            tag.Performers = new[] { trackFile.ArtistName };
            tag.Album = trackFile.AlbumTitle;
            tag.Year = (uint)trackFile.ReleaseYear;
            tag.Genres = null;
            tag.Genres = new[] { trackFile.Genre };
            tag.Title = trackFile.Title;
            tag.Track = (uint)trackFile.TracklistPosition;

            return tag;
        }
    }
}
