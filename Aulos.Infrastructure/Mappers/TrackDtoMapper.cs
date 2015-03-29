using Aulos.Core.Data;
using Aulos.Core.Domain.Entities;
using Aulos.Core.Mappers;
using Aulos.Infrastructure.Data;

namespace Aulos.Infrastructure.Mappers
{
    public class TrackDtoMapper : ITrackDtoMapper
    {
        public Track Map(ITrackDto dto)
        {
            var entity = new Track()
            {
                Title = dto.Title
            };

            return entity;
        }

        public ITrackDto MapToJson(Track track)
        {
            var trackJson = new TrackJsonDto
            {
                Title = track.Title
            };

            return trackJson;
        }
    }
}
