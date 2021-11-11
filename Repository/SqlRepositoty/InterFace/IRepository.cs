using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Data.InterFace
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> FindAll(CancellationToken cancellationToken);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        void AddRenge(IEnumerable<T> entitis);
        void UpdateRenge(IEnumerable<T> entitis);

        Task AddAsync(T entity, CancellationToken cancellation = default);
        Task AddRengeAsync(IEnumerable<T> entitis, CancellationToken cancellation = default);

        //Task AsyncUpdate(T entity, CancellationToken cancellation = default);
        //Task<IQueryable<T>> AsyncFindByCondition(Expression<Func<T, bool>> expression, bool trackChanges, CancellationToken cancellation = default);
        //Task AsyncDelete(T entity, CancellationToken cancellation = default);
        //Task AsyncUpdateRenge(IEnumerable<T> entitis, CancellationToken cancellation = default);
    }
}
