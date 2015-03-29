using Aulos.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aulos.Core.Data;

namespace Aulos.Core.Mappers
{
    public interface IAlbumDtoMapper
    {
        Album Map(IAlbumDto dto);
        IAlbumDto MapToJson(Album album);
    }
}
