using System.Collections.Generic;

namespace Aulos.Core.Data
{
    public interface IAlbumDto : IDataTransferObject
    {
        string ArtistName { get; set; }
        string Title { get; set; }
        int ReleaseYear { get; set; }
        string Genre { get; set; }
        string Duration { get; set; }
        string SourcePath { get; set; }

        IEnumerable<ITrackDto> Tracklist { get; set; }    
    }
}
