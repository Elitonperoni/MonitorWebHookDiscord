using APIProducao.Context;
using APIProducao.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace APIProducao.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected AppDbContext _context;

        public Repository(AppDbContext contexto)
        { 
            _context = contexto;
        }

        public IQueryable<T> Get() 
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> predicate) 
        {
            return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(predicate);
        }

        public async Task<T> GetFilter(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public void Add(T entity)
        {
            _context.Set<T>().AddAsync(entity);  
        }

        public void Delete(T entity) 
        {
            _context.Set<T>().Remove(entity);
        }
            
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
        }
    }
}
