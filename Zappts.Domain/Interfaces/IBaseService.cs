using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zappts.Domain.Entities;

namespace Zappts.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        object Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;

        void Delete(Guid id);
        IList<TEntity> Get();
        TEntity GetById(Guid Id);
        TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
        void ExecuteChangeLog(TEntity obj, string process);

    }
}
