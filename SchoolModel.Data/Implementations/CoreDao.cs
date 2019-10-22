using System;
using System.Collections.Generic;
using System.Text;
using SchoolModel.Data.Contracts;

namespace SchoolModel.Data.Implementations
{
    public class CoreDao<T> : ICoreDao<T> where T : class
    {
        protected readonly Microsoft.EntityFrameworkCore.DbContext _dbContext;

        public CoreDao(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
        }

        public T Get(object id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>();
        }

      

        public void Remove(T entity)
        {
             _dbContext.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            
            foreach (var item in entities)
            {
                Remove(item);
            }
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Attach(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
        }
        public void Reload(T entity)
        {
            _dbContext.Entry(entity).Reload();
        }




    }
}
