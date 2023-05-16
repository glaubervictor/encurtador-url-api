using Microsoft.EntityFrameworkCore;

namespace EncurtadorUrl.Api.Data.Extensions
{
    public static class DbContextExtensions
    {
        public static void UpdateEntry<TEntity>(this DbContext dbContext, int key, object modifiedFields) where TEntity : class
        {
            var entity = dbContext.Set<TEntity>().Find(key);
            dbContext.Attach(entity);
            dbContext.Entry(entity).CurrentValues.SetValues(modifiedFields);
        }

        public static async Task UpdateEntryAsync<TEntity>(this DbContext dbContext, int key, object modifiedFields) where TEntity : class
        {
            var entity = await dbContext.Set<TEntity>().FindAsync(key);
            dbContext.Attach(entity);
            dbContext.Entry(entity).CurrentValues.SetValues(modifiedFields);
        }

        public static void RemoveEntry<TEntity>(this DbContext dbContext, TEntity entity) where TEntity : class
        {
            dbContext.Entry(entity).State = EntityState.Deleted;
        }
    }
}
