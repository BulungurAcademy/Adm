using Adm.Core.BaseModels.BaseEntities;
using System.Linq.Expressions;

namespace Adm.Core.Services.BaseCrudService;
public interface IBaseCrudService<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
{
    Task<IQueryable<TEntity>> GetAllAsync();
    Task<TEntity> GetAsync(TPrimaryKey id);
    Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);
    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

    Task<TEntity> InsertAsync(TEntity entity);
    Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);

    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction);

    Task DeleteAsync(TEntity entity);
    Task DeleteAsync(TPrimaryKey id);
    Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
}
