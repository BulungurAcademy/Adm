namespace Adm.Core.Services;

public interface IServiceBase<TEntity, in TPrimaryKey> : IQueryable<TEntity>
{
    IQueryable<TEntity> GetAllAsQueryable(bool asNoTracking = false);
    Task<TEntity?> GetByIdAsync(TPrimaryKey id, bool asNoTracking = false);
    Task<TEntity> AddAsync(TEntity entity);
    Task AddRangeAsync(params TEntity[] entities);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task UpdateRangeAsync(params TEntity[] entities);
    Task<TEntity> RemoveAsync(TEntity entity);
    Task RemoveRangeAsync(params TEntity[] entity);
    Task<bool> ExistsAsync(TPrimaryKey id);
    Task ExistsOrThrowsNotFoundException(TPrimaryKey id);
    Task<TEntity> GetByIdOrThrowsNotFoundException(TPrimaryKey id);
    Task<TValue?> GetNextSequenceValue<TValue>(string name, string? schemaName) where TValue : struct;
}
