using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Core.Domain.Entities
{
    public class Track : IEntity
    {
        public int TracklistPosition { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
