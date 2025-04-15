using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CapstoneProject.Business.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CapstoneProject.Data.Repositories
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        private readonly DbSet<TEntity> _entity;
        private readonly TContext _context;

        public Repository(TContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
            try
            {
                _entity.Add(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                _entity.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            try
            {
                _entity.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>>? orderBy = null, bool isAscending = true)
        {
            var query = _entity.AsQueryable();

            if (orderBy != null)
            {
                if (isAscending)
                {
                    query = query.OrderBy(orderBy);
                }
                else
                {
                    query = query.OrderByDescending(orderBy);
                }
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, object>>? orderBy = null, bool isAscending = true)
        {
            var query = _entity.AsQueryable();

            if (orderBy != null)
            {
                if (isAscending)
                {
                    query = query.OrderBy(orderBy);
                }
                else
                {
                    query = query.OrderByDescending(orderBy);
                }
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.ToListAsync();
        }
    }
}
