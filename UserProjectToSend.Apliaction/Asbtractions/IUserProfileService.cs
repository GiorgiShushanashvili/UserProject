using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProjectTosend.Domain.DTOs;

namespace UserProjectToSend.Apliaction.Asbtractions;

public interface IUserProfileService
{
    Task<List<UserProfileDTO>> GetAllUserProfiles();
    Task<List<UserProfileDTO>> GetUserProfileByName(string name);
    Task AddNewUserProfileAsync(UserProfileDTO profile);
    Task UpdateUserProfileAsync(UserProfileToUpdateDTO profile);
    Task DeleteUserProfileAsync(int id);
}
