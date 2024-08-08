﻿namespace Adm.Core.Services;

public interface IServiceBase<T, in TId> : IQueryable<T>
{
    IQueryable<T> GetAllAsQueryable(bool asNoTracking = false);
    Task<T?> GetByIdAsync(TId id, bool asNoTracking = false);
    Task<T> AddAsync(T entity);
    Task AddRangeAsync(params T[] entities);
    Task<T> UpdateAsync(T entity);
    Task UpdateRangeAsync(params T[] entities);
    Task<T> RemoveAsync(T entity);
    Task RemoveRangeAsync(params T[] entity);
    Task<bool> ExistsAsync(TId id);
    Task ExistsOrThrowsNotFoundException(TId id);
    Task<T> GetByIdOrThrowsNotFoundException(TId id);
    Task<TValue?> GetNextSequenceValue<TValue>(string name, string? schemaName) where TValue : struct;
}
