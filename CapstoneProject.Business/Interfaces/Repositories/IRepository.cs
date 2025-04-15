using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject.Business.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>>? orderBy = null, bool isAscending = true);
        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>>? predicate = null, Expression<Func<TEntity, object>>? orderBy = null, bool isAscending = true);
    }
}
