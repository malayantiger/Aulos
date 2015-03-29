using Aulos.Core.Data;
using Aulos.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Infrastructure.Factories
{
    public class TrackDtoFactory : ITrackDtoFactory
    {
        public ITrackDto Create(TagLib.Tag trackMetadata)
        {
            return new TagLibTrackFileDtoAdapter(trackMetadata);
        }
    }
}
