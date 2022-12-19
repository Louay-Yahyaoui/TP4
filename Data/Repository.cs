using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace TP4.Data
{
    public class Repository<TEntity> :IRepository<TEntity> where TEntity : class
    {
        protected readonly UniversityContext _context;

        public Repository()

        {
            _context = UniversityContext.getInstance();
        }
        public bool Add(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                return true;
            }
            catch(Exception e) 
            { 
                Console.WriteLine(e.Message);
                return false; 
            }
            
        }

        public bool AddRange(IEnumerable<TEntity> entities)
        {
            
            try
            {
                _context.Set<TEntity>().AddRange(entities);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool RemoveRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _context.Set<TEntity>().RemoveRange(entities);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }
    }
}
