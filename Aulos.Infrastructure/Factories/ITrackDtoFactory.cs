using Aulos.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Infrastructure.Factories
{
    public interface ITrackDtoFactory
    {
        ITrackDto Create(TagLib.Tag trackMetadata);
    }
}
