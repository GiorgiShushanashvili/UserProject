using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProjectTosend.Domain.Abstractions;
using UserProjectTosend.Domain.Models;

namespace UserProjectToSend.Dal.Repository;

public class UserProfileRepository:GenericRepository<UserProfile>,IUserProfileRepository
{
    public UserProfileRepository(UserProjectDbContext context):base(context) { }
}
