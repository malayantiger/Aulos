﻿using Aulos.Core.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Infrastructure.Data
{
    public class TrackJsonDto : ITrackDto
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }
}