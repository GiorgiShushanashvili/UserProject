using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProjectTosend.Domain.DTOs;

namespace UserProjectToSend.Apliaction.AbstractionServices;

public interface IUserProfileService
{
    Task<List<UserProfileDTO>> GetAllUserProfiles();
    Task<UserProfileDTO> GetUserProfileById(int id);
}
