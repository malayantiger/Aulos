using Aulos.Core.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Core.Infrastructure.Services
{
    public interface IFileProvider
    {
        IEnumerable<ITrackFile> GetAlbum(string albumPath);
        ITrackFile GetTrack(string filePath);
        void SaveAlbum(IEnumerable<ITrackFile> tracks);
    }
}
