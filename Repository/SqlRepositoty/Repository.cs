using Data.InterFace;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected AppDbContext _context;
        private DbSet<T> Entities { get; }
        protected virtual IQueryable<T> Table => Entities;
        protected virtual IQueryable<T> TableNoTracking => Entities.AsNoTracking();
        public Repository(AppDbContext context)
        {
            _context = context;
            Entities = _context.Set<T>();
        }

        public virtual IQueryable<T> FindAll(CancellationToken cancellationToken)
        {
            return   TableNoTracking;

        }

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ? TableNoTracking.Where(expression) : Table.Where(expression);
        }

        public virtual void Add(T entity)
        {
            Entities.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            Entities.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            Entities.Update(entity);
        }

        public virtual void UpdateRenge(IEnumerable<T> entitis)
        {
            Entities.UpdateRange(entitis);
        }

        public virtual void AddRenge(IEnumerable<T> entitis)
        {
            Entities.AddRange(entitis);
        }

        #region Async
        public virtual async Task AddAsync(T entity, CancellationToken cancellation = default)
        {
            await Entities.AddAsync(entity, cancellation);
        }

        public virtual async Task AddRengeAsync(IEnumerable<T> entitis, CancellationToken cancellation = default)
        {
            await Entities.AddRangeAsync(entitis, cancellation);
        }
        #endregion
    }
}
