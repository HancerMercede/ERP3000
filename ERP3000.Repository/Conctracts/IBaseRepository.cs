using System.Linq.Expressions;

namespace ERP3000.Repository.Conctracts;

public interface IBaseRepository<T>
{
    IQueryable<T> FindAll(bool trackChanges);
    IQueryable<T> FindByCondiction(Expression<Func<T, bool>> expression, bool trackChanges);
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}
