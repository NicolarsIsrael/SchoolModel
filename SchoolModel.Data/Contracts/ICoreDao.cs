using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolModel.Data.Contracts
{
    public interface ICoreDao<T> where T : class
    {
        /// <summary>
        /// Add single entity to the store
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Add a collection of entities to the store
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(IEnumerable<T> entities);

        /// <summary>
        /// Get single entity from the store
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(object id);

        /// <summary>
        /// Gets all entities from the store
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Find entity or group of entities matching a given expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        //IEnumerable<T> FindUsingDictionary(Dictionary<string, object> dictionary);

        /// <summary>
        /// Remove single entity from the collection
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);

        /// <summary>
        /// Removes a group of entities from the collection
        /// </summary>
        /// <param name="predicate"></param>
        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);

        void Attach(T entity);
       

        void Reload(T entity);
    }
}
