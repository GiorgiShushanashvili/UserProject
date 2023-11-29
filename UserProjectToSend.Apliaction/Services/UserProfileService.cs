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
}
