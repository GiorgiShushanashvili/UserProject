using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProjectTosend.Domain.Models;

namespace UserProjectTosend.Domain.Abstractions;

public interface IUserProfileRepository:IGenericRepository<UserProfile>
{
}
