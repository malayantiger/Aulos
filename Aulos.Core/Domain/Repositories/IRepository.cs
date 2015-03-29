using Aulos.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aulos.Core.Domain.Repositories
{
    public interface IRepository<TAggregate, in TKey> where TAggregate : IAggregate
    {
        TAggregate Get(TKey id);
        void Save(TAggregate aggregate);
        void Delete(TAggregate aggregate);
    }
}
