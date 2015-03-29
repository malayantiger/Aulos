using Aulos.Core.Data;
using Aulos.Core.Domain.Entities;

namespace Aulos.Core.Mappers
{
    public interface ITrackDtoMapper
    {
        Track Map(ITrackDto dto);
        ITrackDto MapToJson(Track track);
    }
}
