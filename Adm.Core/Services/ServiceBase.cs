using Adm.Core.BaseModels.BaseEntities;
using Adm.Core.DbContext;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;

namespace Adm.Core.Services
{
    public class ServiceBase<T, TId> : IServiceBase<T, TId>,
        IQueryable<T>,
        IAsyncEnumerable<T>
        where T : class 
        where TId : class
    {
        private readonly BaseDbContext _context;
        public ServiceBase(BaseDbContext context)
        {
            this._context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            var addedEntityEntry = await this._context
                .Set<T>()
                .AddAsync(entity);

            await this.SaveChangesAsync();

            return addedEntityEntry.Entity;
        }
        public async Task AddRangeAsync(params T[] entities)
        {
            this._context.Set<T>()
                .AddRange(entities);

            await this.SaveChangesAsync();
        }
        public async Task<T> UpdateAsync(T entity)
        {
            var updatedEntityEntry = this._context
                .Set<T>()
                .Update(entity);

            await this.SaveChangesAsync();

            return updatedEntityEntry.Entity;
        }
        public async Task UpdateRangeAsync(params T[] entities)
        {
            this._context.Set<T>()
                .UpdateRange(entities);

            await this.SaveChangesAsync();
        }
        public async Task<T> RemoveAsync(T entity)
        {
            var removedEntityEntry = this._context
                .Set<T>()
                .Remove(entity);

            await this.SaveChangesAsync();

            return removedEntityEntry.Entity;
        }
        public async Task RemoveRangeAsync(params T[] entities)
        {
            this._context.Set<T>()
                .RemoveRange(entities);

            await this.SaveChangesAsync();
        }
        public IQueryable<T> GetAllAsQueryable(bool asNoTracking = false)
        {
            return asNoTracking
                ? this._context.Set<T>().AsNoTracking()
                : this._context.Set<T>();
        }










        public Task<T?> GetByIdAsync(TId id, bool asNoTracking = false)
        {
            throw new NotImplementedException();
        }
        public Task<bool> ExistsAsync(TId id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdOrThrowsNotFoundException(TId id)
        {
            throw new System.Exception(" not found by {id}");
        }






        public async Task ExistsOrThrowsNotFoundException(TId id)
        {
            if (!await this.ExistsAsync(id))
                throw new System.Exception($"{typeof(T).Name} not found by {id}");
        }
        public async Task<TValue?> GetNextSequenceValue<TValue>(string name, string? schemaName)
            where TValue : struct
        {
            return await this._context.Database
                .SqlQueryRaw<TValue>("select nextval('{0}') as \"Value\"", $"{schemaName ?? "public"}.{name}")
                .FirstOrDefaultAsync();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this.GetAllAsQueryable()
                .GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return this._context.Set<T>()
                .GetAsyncEnumerator(cancellationToken);
        }
        private async Task SaveChangesAsync() => await this._context.SaveChangesAsync();
        public Type ElementType { get => this.GetAllAsQueryable().ElementType; }
        public Expression Expression { get => this.GetAllAsQueryable().Expression; }
        public IQueryProvider Provider { get => this.GetAllAsQueryable().Provider; }
    }
}
