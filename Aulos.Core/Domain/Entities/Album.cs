using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Core.Domain.Entities
{
    public class Album : IAggregate
    {
        protected List<Track> _tracklist = new List<Track>();

        public Artist Artist { get; set; }
        public string Title { get; set; }
        public List<Track> Tracklist { get { return _tracklist; } }
        public string SourcePath { get; set; }

        public void AddTrack(Track track)
        {
            _tracklist.Add(track);
        }
    }
}
