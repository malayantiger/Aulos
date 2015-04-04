using Aulos.Core.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Infrastructure.Factories
{
    public interface ITrackFileFactory
    {
        ITrackFile Create(TagLib.Tag trackMetadata, TagLib.Properties trackProperties, string filePath);
    }
}
