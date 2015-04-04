namespace Aulos.Core.Data
{
    public interface ITrackDto : IDataTransferObject
    {
        int TracklistPosition { get; set; }
        string Title { get; set; }
        string Duration { get; set; }
    }
}
