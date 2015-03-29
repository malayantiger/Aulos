using Aulos.Core.Data;
using System.Collections.Generic;

namespace Aulos.Infrastructure.Factories
{
    public interface IAlbumFileDtoFactory
    {
        IAlbumDto Create(TagLib.Tag albumMetadata, IList<ITrackDto> trackFilesDtos, string sourcePath);
    }
}
