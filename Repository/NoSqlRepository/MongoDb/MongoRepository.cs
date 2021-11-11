using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Utility;

namespace Data.NoSqlRepository.MongoDb
{
    public class MongoRepository<Entity, Dto> : IMongoRepository<Entity, Dto>
        where Entity : CommonEvent<Dto>
        where Dto : class
    {
        private readonly MongoDbSetting mogoDbSetting;
        private IMongoCollection<Entity> collection;

        public MongoRepository()
        {

            this.mogoDbSetting = null;
            Setting(this.mogoDbSetting);
        }

        public MongoRepository(MongoDbSetting mogoDbSetting)
        {
            this.mogoDbSetting = mogoDbSetting;
            Setting(this.mogoDbSetting);
        }

        private void Setting(MongoDbSetting mogoDbSetting)
        {
            var client = new MongoClient(mogoDbSetting.ConnectionSting);
            var databaseName = new MongoUrl(mogoDbSetting.ConnectionSting).DatabaseName;
            var database = client.GetDatabase(databaseName);
            collection = database.GetCollection<Entity>(typeof(Entity).Name);
        }

        public async Task<Entity> GetByCondition(Expression<Func<Entity, bool>> expression)
        {
            return await collection.AsQueryable().Where(expression).FirstOrDefaultAsync();
        }

        public Entity GetById(string id)
        {
            return collection.Find(f => f.Id == id).FirstOrDefault<Entity>();
        }

        public async Task<Entity> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await collection.Find(f => f.Id == id).FirstOrDefaultAsync<Entity>(cancellationToken);
        }

        public async Task<List<Entity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await collection.AsQueryable().ToListAsync(cancellationToken);
        }

        public List<Entity> GetAll()
        {
            return collection.AsQueryable().ToList();
        }

        public async Task InsertOneAsync(Entity entity, CancellationToken cancellationToken = default)
        {
            await collection.InsertOneAsync(entity, new InsertOneOptions { BypassDocumentValidation = false }, cancellationToken);
        }

        public void Insert(Entity entity)
        {
            collection.InsertOne(entity, new InsertOneOptions { BypassDocumentValidation = false });
        }

        public async Task DeleteAsync(Entity entity, CancellationToken cancellationToken = default)
        {
            await collection.DeleteOneAsync(d => d.Id == entity.Id, cancellationToken);
        }

        public void Delete(Entity entity)
        {
            collection.DeleteOne(d => d.Id == entity.Id);
        }
    }
}
