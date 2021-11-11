using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Data.NoSqlRepository.MongoDb
{
    public interface IMongoRepository<Entity, Dto>
        where Entity : CommonEvent<Dto>
        where Dto : class
    {
        //T GetById(Expression<Func<T, bool>> expression);
        Task<Entity> GetByCondition(Expression<Func<Entity, bool>> expression);
        Entity GetById(string id);
        Task<Entity> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<List<Entity>> GetAllAsync(CancellationToken cancellationToken = default);
        List<Entity> GetAll();
        void Insert(Entity entity);
        Task InsertOneAsync(Entity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(Entity entity, CancellationToken cancellationToken = default);
        void Delete(Entity entity);
    }
}
