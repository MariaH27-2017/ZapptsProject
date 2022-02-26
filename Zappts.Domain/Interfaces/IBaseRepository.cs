using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zappts.Domain.Entities;

namespace Zappts.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(Guid Id);
        IList<TEntity> Select();
        TEntity Select(Guid id);
        IList<TEntity> Consult(Func<TEntity, bool> filter);
        IList<TEntity> OrderBy(Func<TEntity, bool> filter);

    }
}
