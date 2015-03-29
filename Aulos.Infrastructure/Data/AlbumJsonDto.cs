using Aulos.Core.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aulos.Infrastructure.Data
{
    public class AlbumJsonDto : IAlbumDto
    {
        [JsonProperty(PropertyName = "artist")]
        public string ArtistName { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "tracklist")]
        public IEnumerable<ITrackDto> Tracklist { get; set; }

        [JsonProperty(PropertyName = "path")]
        public string SourcePath { get; set; }

        public AlbumJsonDto()
        {
            Tracklist = new List<TrackJsonDto>();
        }
    }
}
