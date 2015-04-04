using Aulos.Core.Infrastructure.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Infrastructure.Data
{
    public class TrackJsonDto
    {
        [JsonProperty(PropertyName = "track")]
        public int TracklistPosition { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public string Duration { get; set; }
    }
}
