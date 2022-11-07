using System.Linq.Expressions;

namespace HotelManagementSystem.Server.Contracts
{
    /// <summary>
    /// Generic interface to hold all CRUD methods
    /// 
    /// trackChanges parameter
    /// used to improve read-only query performance. When it’s set to false, we
    /// attach the AsNoTracking method to our query to inform EF Core that it doesn’t need to track changes
    /// for the required entities.This greatly improves the speed of a query
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// find all
        /// </summary>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        IQueryable<T> FindAll(bool trackChanges);
        
        /// <summary>
        /// find guest by
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        
        /// <summary>
        /// create new
        /// </summary>
        /// <param name="entity"></param>
        void Create(T entity);
        
        /// <summary>
        /// update
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
        
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
    }
}
