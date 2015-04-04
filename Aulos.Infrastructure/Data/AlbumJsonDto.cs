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

        [JsonProperty(PropertyName = "year")]
        public int ReleaseYear { get; set; }

        [JsonProperty(PropertyName = "genre")]
        public string Genre { get; set; }

        [JsonProperty(PropertyName = "tracks")]
        public int TotalTracksCount { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public string Duration { get; set; }

        [JsonProperty(PropertyName = "path")]
        public string SourcePath { get; set; }

        [JsonProperty(PropertyName = "tracklist")]
        public IEnumerable<ITrackDto> Tracklist { get; set; }

        public AlbumJsonDto()
        {
            Tracklist = new List<TrackJsonDto>();
        }
    }
}
