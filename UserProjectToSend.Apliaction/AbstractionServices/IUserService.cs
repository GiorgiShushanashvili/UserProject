using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProjectTosend.Domain.DTOs;

namespace UserProjectToSend.Apliaction.AbstractionServices;

public interface IUserService
{
    Task Registration(UserDTOToAdd userdto);
    Task UpdateUserAsync(UserDTOToUpdate userDtoToUpdate);
    Task DeleteUserAsync(int id);
}
