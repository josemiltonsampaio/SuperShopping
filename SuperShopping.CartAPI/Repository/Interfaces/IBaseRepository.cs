using System.Linq.Expressions;

namespace SuperShopping.CartAPI.Repository.Interfaces;
public interface IBaseRepository<T>
{
    IQueryable<T> GetAll(bool trackChanges);
    IQueryable<T> GetAllByQuery(Expression<Func<T, bool>> query, bool trackChanges);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}
