using Aulos.Core.Data;
using Aulos.Core.Domain.Entities;
using Aulos.Infrastructure.Data;
using System;

namespace Aulos.Infrastructure.Mappers
{
    public static class TrackDtoMapper
    {
        public static Track MapToEntity(this ITrackDto dto)
        {
            var entity = new Track()
            {
                TracklistPosition = dto.TracklistPosition,
                Title = dto.Title,
                Duration = TimeSpan.Parse(dto.Duration)
            };

            return entity;
        }

        public static ITrackDto MapToJson(this Track track)
        {
            var trackJson = new TrackJsonDto
            {
                TracklistPosition = track.TracklistPosition,
                Title = track.Title,
                Duration = track.Duration.ToString(@"hh\:mm\:ss")
            };

            return trackJson;
        }
    }
}
