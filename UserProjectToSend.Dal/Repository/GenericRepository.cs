using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserProjectTosend.Domain.Abstractions;
using UserProjectTosend.Domain.Exceptions;

namespace UserProjectToSend.Dal.Repository;

public class GenericRepository<T>:IGenericRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;
    private readonly UserProjectDbContext _context;
    public GenericRepository(UserProjectDbContext userProjectDbContext)
    {
        _context = userProjectDbContext;
        _dbSet = _context.Set<T>();
    }

    public IQueryable<T> Table => _dbset;

    public virtual async Task<IQueryable<T>> GetAllAsync()
    {
        return await Task.FromResult(_dbSet.AsNoTracking());
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public ValueTask UpdateAsync(T entity)
    {
        if (entity == null) throw new ArgumentException("Something Is Wrong");
        _dbSet.Attach(entity);
        var item = _context.Entry(entity);
        item.State = EntityState.Modified;
        item.CurrentValues.SetValues(entity);
        return ValueTask.CompletedTask;
    }
    public async ValueTask AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public virtual ValueTask DeleteAsync(T entity)
    {
         _dbSet.Remove(entity);
        return ValueTask.CompletedTask;
    }
    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
    }
}
