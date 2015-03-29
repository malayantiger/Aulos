using System.Collections.Generic;

namespace Aulos.Core.Data
{
    public interface IAlbumDto : IDataTransferObject
    {
        string ArtistName { get; set; }
        string Title { get; set; }
        IEnumerable<ITrackDto> Tracklist { get; set; }
        string SourcePath { get; set; }
    }
}
