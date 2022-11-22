using RouletteGameApi.Models;
using RouletteGameApi.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RouletteGameApi.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly RouletteGameContext _db;
        public Repository(RouletteGameContext db)
        {
            _db = db;
        }
        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _db.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
        public Task<List<TEntity>> GetAllAsync()
        {
            try
            {
                return _db.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
        public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                return _db.Set<TEntity>().Where(where).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
        public Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                return _db.Set<TEntity>().Where(where).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't find entities: {ex.Message}");
            }
        }
        public void Create(TEntity entity) => _db.Set<TEntity>().Add(entity);
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _db.AddAsync(entity);
                await _db.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _db.Update(entity);
                await _db.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(DeleteAsync)} entity must not be null");
            }

            try
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be deleted: {ex.Message}");
            }
        }
    }
}
