using Microsoft.EntityFrameworkCore;
using Skillz.Data;
using Skillz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Skillz.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SkillzDbContext _dbContext;
        protected readonly DbSet<T> ModelDbSets;

        public Repository(SkillzDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException();
            ModelDbSets = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            ModelDbSets.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            ModelDbSets.AddRange(entities);
        }

        public async Task<T> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await ModelDbSets.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetListAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await ModelDbSets.AsNoTracking().Where(predicate).ToListAsync();
        }

        public System.Linq.IQueryable<T> Query(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return ModelDbSets.Where(predicate);
        }

        public System.Linq.IQueryable<T> All()
        {
            return ModelDbSets;
        }

        public void Remove(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached) ModelDbSets.Attach(entity);
            ModelDbSets.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                this.Remove(entity);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            ModelDbSets.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
