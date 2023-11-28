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
    public IUserRepository UserRepository { get; }
    public IUserProfileRepository UserProfileRepository { get; }
    private bool _disposed;
    public UnitOfWorkRepository(UserProjectDbContext context,IUserProfileRepository userProfileRepository,IUserRepository userRepository)
    {
        _context = context;
        this.UserRepository = userRepository;
        this.UserProfileRepository = userProfileRepository;
        _disposed = false;
    }

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
