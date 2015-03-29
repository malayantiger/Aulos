using Aulos.Core.Data;
using Aulos.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Core.Mappers
{
    public interface IMapToNew<TDto, TEntity>
    {
        TEntity MapToEntity(TDto dto);
        TDto MapToDto(TEntity entity);
    }

    public interface IMapToExisting<TSource, TTarget>
    {
        void Map(TSource source, TTarget target);
    }
}
