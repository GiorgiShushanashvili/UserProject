using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserProjectTosend.Domain.Abstractions;
using UserProjectTosend.Domain.DTOs;
using UserProjectTosend.Domain.Exceptions;
using UserProjectTosend.Domain.Models;
using UserProjectToSend.Apliaction.AbstractionServices;

namespace UserProjectToSend.Apliaction.Services;

public class UserProfileService:IUserProfileService
{
    private readonly IUnitOfWorkRepository _unitOfWorkRepository;
    private readonly IMapper _mapper;
    public UserProfileService(IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
    {
        _unitOfWorkRepository = unitOfWorkRepository;
        _mapper = mapper;
    }

    public async Task<List<UserProfileDTO>> GetAllUserProfiles()
    {
        List<UserProfileDTO> userProfiles = new();
        var userProfileData= await _unitOfWorkRepository.UserProfileRepository.GetAllAsync();
        var listOfUsers = _mapper.Map<List<UserProfileDTO>>(userProfileData);
        foreach(var userProfile in listOfUsers )
        {
            if (!userProfiles.Contains(userProfile))
            {
                userProfiles.Add(userProfile);
            }
        }
        if(!userProfiles.Any()) throw new NoUsersException();
        return userProfiles;
    }
    
    public async Task<UserProfileDTO> GetUserProfileById(int id)
    {
        try
        {
            var userProfiles = await _unitOfWorkRepository.UserProfileRepository.FindAsync(x => x.Id == id);
            if (userProfiles == null) throw new NoUserOnThisNameException();
            var users = _mapper.Map<UserProfileDTO>(userProfiles);
            return users;
        }
        catch (Exception e)
        {

            throw e;
        }
    }

    /*public async Task AddNewUserProfileAsync(UserProfileDTO profile)
    {
        var check = await _unitOfWorkRepository.UserProfileRepository.Table.AnyAsync(x=>x.personalNumber == profile.personalNumber);
        if(check) throw new UserProfileAlreadyExistsException();
        await _unitOfWorkRepository.UserProfileRepository.AddAsync(_mapper.Map<UserProfile>(profile));
        await _unitOfWorkRepository.SaveChangesAsync();
    }*/

    /*public async Task UpdateUserProfileAsync(UserProfileToUpdateDTO profile)
    {
        var userProfile = await _unitOfWorkRepository.UserProfileRepository.GetByIdAsync(profile.Id);
        if (userProfile == null) throw new NoUsersException();
        await _unitOfWorkRepository.UserProfileRepository.UpdateAsync(_mapper.Map<UserProfile>(profile));
        await _unitOfWorkRepository.SaveChangesAsync();
    }*/

    /*public async Task DeleteUserProfileAsync(int id)
    {
        var userToDelete = await _unitOfWorkRepository.UserProfileRepository.GetByIdAsync(id);
        if (userToDelete == null) throw new NoUsersException();
        await _unitOfWorkRepository.UserProfileRepository.DeleteAsync(userToDelete);
        await _unitOfWorkRepository.SaveChangesAsync();
    }*/
}
