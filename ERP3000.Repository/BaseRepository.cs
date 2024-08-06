using ERP3000.Repository.Conctracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ERP3000.Repository;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected ApplicationDbContext _context;
    public BaseRepository(ApplicationDbContext context) => _context = context;


    public IQueryable<T> FindAll(bool trackChanges) =>
    !trackChanges ?
       _context.Set<T>().AsNoTracking()
         : _context.Set<T>();

    public IQueryable<T> FindByCondiction(Expression<Func<T, bool>> expression, bool trackChanges) =>
        !trackChanges ?
          _context.Set<T>().Where(expression).AsNoTracking() :
        _context.Set<T>().Where(expression);
  

    public async Task Update(T entity) => await Task.FromResult(_context.Set<T>().Update(entity));
    public async Task Create(T entity) => await _context.Set<T>().AddAsync(entity);
    public async Task Delete(T entity) => await Task.FromResult(_context.Set<T>().Remove(entity));
}
