using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UserProjectTosend.Domain.Abstractions;

public interface IGenericRepository<T> where T : class
{
    public Task<IQueryable<T>> GetAllAsync();
    public Task<T?> GetByIdAsync(int id);
    //public Task<T?> FindAsync(Expression<Func<T, bool>> predicate);
    public ValueTask AddAsync(T entity);
    public ValueTask UpdateAsync(T entity);
    public ValueTask DeleteAsync(T entity);
    public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    IQueryable<T> Table { get; }
}
