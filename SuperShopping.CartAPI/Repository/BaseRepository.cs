using Microsoft.EntityFrameworkCore;
using SuperShopping.CartAPI.Data;
using SuperShopping.CartAPI.Repository.Interfaces;
using System.Linq.Expressions;

namespace SuperShopping.CartAPI.Repository;
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }


    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public IQueryable<T> GetAll(bool trackChanges)
    {
        if (!trackChanges)
        {
            return _context.Set<T>().AsNoTracking();
        }

        return _context.Set<T>();
    }

    public IQueryable<T> GetAllByQuery(Expression<Func<T, bool>> query, bool trackChanges)
    {
        if (!trackChanges)
        {
            return _context.Set<T>().Where(query).AsNoTracking();
        }
        return _context.Set<T>().Where(query);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}
