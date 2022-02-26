using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zappts.Domain.Entities;
using Zappts.Domain.Interfaces;
using Zappts.Infra.Data.Context;

namespace Zappts.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private ApplicationDbContext _context { get; }
        private DbSet<TEntity> tableDb;
        public BaseRepository()
        {
            _context = new ApplicationDbContext();
            tableDb = _context.Set<TEntity>();
        }

       

        public async void Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Insert(TEntity obj)
        {
            tableDb.Add(obj);
            Commit();
        }

        public void Update(TEntity obj)
        {
            tableDb.Update(obj);
            Commit();
        }

        public TEntity Select(Guid Id) => tableDb.Find(Id);
        public IList<TEntity> Select() => tableDb.ToList();
        public IList<TEntity> Consult(Func<TEntity, bool> filter) => tableDb.Where(filter).ToList();
        public void Delete(Guid id) => tableDb.Remove(Select(id));

        IList<TEntity> IBaseRepository<TEntity>.OrderBy(Func<TEntity, bool> rule) => tableDb.OrderBy(rule).ToList();
        
    }
}
