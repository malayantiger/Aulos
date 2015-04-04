using Aulos.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Infrastructure.Data
{
    public class TagLibTrackFileDtoAdapter : ITrackDto
    {
        private readonly TagLib.Tag _trackMetadata;
        private readonly TagLib.Properties _trackProperties;

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

        public TagLibTrackFileDtoAdapter(TagLib.Tag trackMetadata, TagLib.Properties trackProperties)
        {
            if (trackMetadata == null)
                throw new ArgumentNullException("Track metadata cannot be null.");

            if (trackProperties == null)
                throw new ArgumentNullException("Track properties cannot be null.");

            _trackMetadata = trackMetadata;
            _trackProperties = trackProperties;
        }
    }
}
