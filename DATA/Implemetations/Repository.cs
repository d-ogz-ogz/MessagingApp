using COMMON.interfaces;
using DATA.Db;
using Microsoft.EntityFrameworkCore;
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
        public Repository(MessagingAppDbContext context, string collectionName)
        {
            _collection = context.GetCollection<T>(collectionName);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
     public async Task<List<T>> GetFilteredAsync(Expression<Func<T,bool>> filter)
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
            await _collection.ReplaceOneAsync(x => x.Id == id, entity);
        }

        public async Task DeleteAsync(string id)

        {
            //var filter = Builders<T>.Filter.Eq("Id", id);
            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
   
