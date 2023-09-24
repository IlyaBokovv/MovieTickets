using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.DataAccess.Repository.IRepository
{
    public interface IRepositoryBase<T> where T : class, IEntityBase, new()
    {
        public Task<T> AddAsync(T entity);
        public Task<IEnumerable<T>> GetAllAsync(bool trackChanges = false);
        public Task<IEnumerable<T>> GetAllAsync(bool trackChanges = false, params Expression<Func<T, object?>>[] includeProperties);
        public Task<T?> GetByIdAsync(int id, bool trackChanges = false);
        public Task<T?> GetByIdAsync(int id, bool trackChanges = false, params Expression<Func<T, object?>>[] includeProperties);
        public Task DeleteAsync(int id);
        public Task<int> UpdateAsync(T entity);
    }
}
