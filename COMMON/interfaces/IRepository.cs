using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace COMMON.interfaces
{
    public interface IRepository<T> where T : IEntity
    {

        public Task<List<T>> GetAllAsync();

        public Task<T> GetByIdAsync(string id);

        public Task CreateAsync(T entity);
        public  Task<List<T>> GetFilteredAsync(Expression<Func<T, bool>> filter);

        public Task UpdateAsync(string id, T entity);

        public  Task DeleteAsync(string id);
      
    }
}



