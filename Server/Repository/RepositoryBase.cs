using HotelManagementSystem.Server.Contracts;
using HotelManagementSystem.Server.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelManagementSystem.Server.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// database context class
        /// </summary>
        protected ApplicationDbContext ApplicationDbContext;
        
        /// <summary>
        /// Repository constructor with dbContext dependency injection
        /// </summary>
        /// <param name="applicationDbContext"></param>
        public RepositoryBase(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        /// <summary>
        /// Create entity
        /// </summary>
        /// <param name="entity"></param>
        public void Create(T entity) => ApplicationDbContext.Set<T>().Add(entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity) => ApplicationDbContext.Set<T>().Update(entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity) => ApplicationDbContext.Set<T>().Remove(entity);

        /// <summary>
        /// trackChanges used to improve read-only query performance
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>

        public IQueryable<T> FindAll(bool trackChanges)
            => !trackChanges ? 
            ApplicationDbContext.Set<T>().AsNoTracking() :
            ApplicationDbContext.Set<T>();

        /// <summary>
        /// When trackChanges it’s set to false, we attach the AsNoTracking method to our query to inform EF Core that it
        /// doesn’t need to track changes for the required entities.This greatly improves the speed of a query
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
                                             bool trackChanges)
        => !trackChanges ?
            ApplicationDbContext.Set<T>().Where(expression).AsNoTracking() :
            ApplicationDbContext.Set<T>().Where(expression);
    }
}
