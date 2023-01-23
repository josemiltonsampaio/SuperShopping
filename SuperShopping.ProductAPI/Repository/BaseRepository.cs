using Microsoft.EntityFrameworkCore;
using SuperShopping.ProductAPI.Data;
using System.Linq.Expressions;

namespace SuperShopping.ProductAPI.Repository;
public class BaseRepository<T> : IBaseRepository<T> where T : class

{
    protected readonly AppDbContext context;

    public BaseRepository(AppDbContext context)
    {
        this.context = context;
    }
    public void Add(T entity)
    {
        context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        context.Set<T>().Remove(entity);
    }

    public IQueryable<T> GetAll(bool trackChanges)
    {
        if (trackChanges)
        {
            return context.Set<T>();
        }

        return context.Set<T>().AsNoTracking();
    }

    public IQueryable<T> GettAllByQuery(Expression<Func<T, bool>> query, bool trackChanges)
    {
        if (trackChanges)
        {
            return context.Set<T>().Where(query);
        }

        return context.Set<T>().Where(query).AsNoTracking();
    }

    public void Update(T entity)
    {
        context.Set<T>().Update(entity);
    }
}
