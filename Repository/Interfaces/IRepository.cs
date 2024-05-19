using System.Linq.Expressions;

namespace APIProducao.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();

        Task<T> GetById(Expression<Func<T, bool>> predicate);
        Task<T> GetFilter(Expression<Func<T, bool>> predicate);        
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
