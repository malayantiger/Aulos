using Aulos.Core.Data;
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
        IAlbumDto GetAlbum(string albumPath);
        ITrackDto GetTrack(string filePath);
    }
}
