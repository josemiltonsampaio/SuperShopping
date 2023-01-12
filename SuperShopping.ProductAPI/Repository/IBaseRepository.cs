using System.Linq.Expressions;

namespace SuperShopping.ProductAPI.Repository;
public interface IBaseRepository<T>
{
    IQueryable<T> GetAll(bool trackChanges);
    IQueryable<T> GettAllByQuery(Expression<Func<T, bool>> query, bool trackChanges);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}
