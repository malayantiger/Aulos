using Aulos.Infrastructure.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using Aulos.Core.Data;

namespace Aulos.Infrastructure.Factories
{
    public class AlbumFileDtoFactory : IAlbumFileDtoFactory
    {
        public IAlbumDto Create(TagLib.Tag albumMetaData, IList<ITrackDto> trackFiles, string sourcePath)
        {
            var albumDto = new TagLibAlbumFileDtoAdapter(albumMetaData)
                {
                    Tracklist = trackFiles,
                    SourcePath = sourcePath
                };

            return albumDto;
        }
    }
}
