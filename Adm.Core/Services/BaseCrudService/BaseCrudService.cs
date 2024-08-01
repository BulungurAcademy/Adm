using Adm.Core.BaseModels.BaseEntities;
using Adm.Core.DbContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Adm.Core.Services.BaseCrudService
{
    public class BaseCrudService<TEntity, TPrimaryKey> : IBaseCrudService<TEntity, TPrimaryKey>
    where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly BaseDbContext _context;
        public BaseCrudService(BaseDbContext context)
        {
            _context = context;
        }

        #region GET
        public async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public Task<IQueryable<TEntity>> GetAllAsync()
        {
            return Task.FromResult(_context.Set<TEntity>().AsNoTracking().AsQueryable());
        }

        public async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            return await _context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(entity => entity.Id.Equals(id));
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(predicate);
        }
        #endregion

        #region CREATE
        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            var newEntity = await InsertAsync(entity);
            return newEntity.Id;
        }
        #endregion

        #region UPDATE
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction)
        {
            var entity = await this.GetAsync(id);

            if (entity is null)
                throw new ArgumentNullException(nameof(entity), "Entity is null !");

            await updateAction(entity);
            
            return await this.UpdateAsync(entity);
        }
        #endregion

        #region DELETE
        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(TPrimaryKey id)
        {
            var entity = await this.GetAsync(id);
            if (entity != null)
            {
                await this.DeleteAsync(entity);
            }
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = _context.Set<TEntity>().Where(predicate);
            _context.Set<TEntity>().RemoveRange(entities);
            await SaveChangesAsync();
        }
        #endregion

        private async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new InvalidOperationException("Concurrency conflict detected.", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("An error occurred while updating the database.", ex);
            }
            catch (System.Exception ex)
            {
                throw new InvalidOperationException("An error occurred while saving changes.", ex);
            }
        }
    }
}
