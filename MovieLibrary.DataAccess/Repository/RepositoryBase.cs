using Microsoft.EntityFrameworkCore;
using MovieLibrary.DataAccess.Repository.IRepository;
using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.DataAccess.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T>
            where T : class, IEntityBase, new()
    {
        private readonly ApplicationDbContext _db;

        public RepositoryBase(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null)
            {
                throw new NullReferenceException(nameof(entity));
            }
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool trackChanges = false)
        {
            var query = _db.Set<T>().AsQueryable();
            if (!trackChanges)
            {
                query.AsNoTracking();
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool trackChanges = false, params Expression<Func<T, object?>>[] includeProperties)
        {
            var query = _db.Set<T>().AsQueryable<T>();
            if (!trackChanges)
            {
                query.AsNoTracking();
            }
            query = includeProperties.Aggregate(query, (current, includeProperties) => current.Include(includeProperties));
            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id, bool trackChanges = false)
        {
            var query = _db.Set<T>().AsQueryable();
            if (!trackChanges)
            {
                query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T?> GetByIdAsync(int id, bool trackChanges = false, params Expression<Func<T, object?>>[] includeProperties)
        {
            var query = _db.Set<T>().AsQueryable<T>();
            if (!trackChanges)
            {
                query.AsNoTracking();
            }
            query = includeProperties
               .Aggregate(query,
               (current, includeProperties) => current.Include(includeProperties));
            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _db.Set<T>().Entry(entity).State = EntityState.Modified;
            return await _db.SaveChangesAsync();
        }
    }
}
