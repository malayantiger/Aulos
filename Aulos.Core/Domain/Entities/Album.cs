using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Core.Domain.Entities
{
    public class Album : IAggregate
    {
        protected readonly List<Track> _tracklist = new List<Track>();
        protected DateTime _releaseDate = new DateTime();

        public Artist Artist { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get { return _releaseDate; } }
        public string Genre { get; set; }
        public int TotalTracksCount { get { return Tracklist.Count; } }
        public TimeSpan Duration { get { return new TimeSpan(Tracklist.Sum(t => t.Duration.Ticks)); } }
        public string SourcePath { get; set; }
        public List<Track> Tracklist { get { return _tracklist; } }

        public Track this[int index]
        {
            get 
            { 
                if (index < 1 || index > Tracklist.Count)
                    throw new ArgumentException(String.Format("Album track must be in range 1-{0}.", Tracklist.Count));

                return Tracklist[index-1]; 
            }
        }

        public void AddTrack(Track track)
        {
            _tracklist.Add(track);
        }

        public void AddReleaseDate(int year, int month = 1, int day = 1)
        {
            if (year == 0 || month == 0 || day == 0)
                throw new ArgumentException("Release year/month/day must be greater than 0.");

            _releaseDate = new DateTime(year, month, day);
        }
    }
}
