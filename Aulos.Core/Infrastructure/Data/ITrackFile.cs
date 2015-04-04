namespace Aulos.Core.Infrastructure.Data
{
    public interface ITrackFile
    {
        string ArtistName { get; set; }
        string AlbumTitle { get; set; }
        int ReleaseYear { get; set; }
        string Genre { get; set; }
        int TracklistPosition { get; set; }
        string Title { get; set; }
        string Duration { get; set; }
        string AlbumPath { get; }
        string FileName { get; }
        string SourcePath { get; set; }
    }
}
