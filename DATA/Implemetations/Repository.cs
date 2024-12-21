using COMMON.interfaces;
using DATA.Db;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Implemetations
{
    public class Repository<T> : IRepository<T> where T : IEntity


    {
        private readonly IMongoCollection<T> _collection;
        private readonly IMongoClient _mongoClient;

        public Repository(MessagingAppDbContext context, string collectionName)
        {

            _collection = context.GetCollection<T>(collectionName);
            _mongoClient = context.MongoClient;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
        public async Task<List<T>> GetFilteredAsync(Expression<Func<T, bool>> filter)
        {
            var query = _collection.AsQueryable().Where(filter);
            return await query.ToListAsync();
        }
        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(T entity)
        {

            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(string id, T entity)
        {
            var update = Builders<T>.Update.Push("Messages", entity);
            await _collection.UpdateOneAsync(x => x.Id == id, update);

        }

        public async Task DeleteAsync(string id)

        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            await _collection.DeleteOneAsync(filter);
        }


        public async Task CreateWithTransactionAsync(T entity,string updateId,T updateEntity)
        {
            using (var session = await _mongoClient.StartSessionAsync()) {

                session.StartTransaction();
                try
                {
                    
                    await _collection.InsertOneAsync(session, entity);
                    var update = Builders<T>.Update.Set("xx", updateEntity); ;
                    await _collection.UpdateOneAsync(x => x.Id == updateId, update);
                    await session.CommitTransactionAsync();
                }
                catch (Exception)
                {

                    await session.AbortTransactionAsync();
                    throw;
                }
            
            
            }
        }

    }
}

