using Aulos.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.CatelUI.ViewModels
{
    public class AlbumViewModel
    {
        public string ArtistName { get; set; }
        public string Title { get; set; }
        public List<TrackViewModel> Tracklist { get; set; }
        public string SourcePath { get; set; }

        public AlbumViewModel()
        {
            Tracklist = new List<TrackViewModel>();
        }
    }
}
