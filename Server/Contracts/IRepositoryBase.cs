using System.Linq.Expressions;

namespace HotelManagementSystem.Server.Contracts
{
    /// <summary>
    /// Generic interface to hold all CRUD methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// find all
        /// </summary>
        /// <returns></returns>
        IQueryable<T> FindAll();
        
        /// <summary>
        /// find guest by
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        
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
