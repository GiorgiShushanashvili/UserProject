using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProjectTosend.Domain.Abstractions;

public interface IUnitOfWorkRepository:IDisposable
{
    IUserProfileRepository UserProfileRepository { get; }
    IUserRepository UserRepository { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken=default);
}
