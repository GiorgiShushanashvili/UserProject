using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProjectTosend.Domain.Abstractions;

namespace UserProjectToSend.Dal.Repository;

public class UnitOfWorkRepository:IUnitOfWorkRepository
{
    private readonly UserProjectDbContext _context;
    public IUserRepository _userRepository;
    public IUserProfileRepository _userProfileRepository;
    private bool _disposed;
    public UnitOfWorkRepository(UserProjectDbContext context)
    {
        _context = context;
        _disposed = false;
    }
    public IUserProfileRepository UserProfileRepository => _userProfileRepository ??= new UserProfileRepository(_context);
    public IUserRepository UserRepository=>_userRepository ??= new UserRepository(_context);

   public async Task<int> SaveChangesAsync(CancellationToken cancellationToken=default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this._disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
