using HotelManagementSystem.Server.Contracts;
using HotelManagementSystem.Server.Data;
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
        /// 
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> FindAll()
            => ApplicationDbContext.Set<T>();

        /// <summary>
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        => ApplicationDbContext.Set<T>().Where(expression);
    }
}
