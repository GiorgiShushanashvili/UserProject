using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserProjectTosend.Domain.Abstractions;
using UserProjectTosend.Domain.DTOs;
using UserProjectTosend.Domain.Exceptions;
using UserProjectTosend.Domain.Models;
using UserProjectToSend.Apliaction.AbstractionServices;

namespace UserProjectToSend.Apliaction.Services;

public class UserService : IUserService
{
    private readonly ISecurityService _securityService;
    private readonly IUnitOfWorkRepository _unitOfWorkRepository;
    private readonly IMapper _mapper;
    public UserService(IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper,ISecurityService securityService)
    {
        _unitOfWorkRepository = unitOfWorkRepository;
        _mapper = mapper;
        _securityService = securityService;
    }

    public async Task Registration(UserDTOToAdd userdto)
    {
        var res = await _unitOfWorkRepository.UserRepository.Table.AnyAsync(x => x.userName == userdto.userName);
        if (res) throw new UserAlreadyExistsException();
        var newUser = new User()
        {
            userName = userdto.userName,
            password = _securityService.GetPasswordHash(userdto.password),
            email = userdto.email,
            isActive = userdto.isActive,
            profile = new UserProfile() 
            {
                FirstName=userdto.FirstName,
                LastName=userdto.LastName,
                personalNumber = userdto.PersonalNumber,
            }
        };

        await _unitOfWorkRepository.UserRepository.AddAsync(newUser);
        await _unitOfWorkRepository.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(UserDTOToUpdate userDtoToUpdate)
    {
        var activeUser = await _unitOfWorkRepository.UserRepository.GetByIdAsync(userDtoToUpdate.Id);
        if(activeUser == null) throw new NoUsersException();

        activeUser.userName = userDtoToUpdate.userName;
        activeUser.password = _securityService.GetPasswordHash(userDtoToUpdate.password);
        activeUser.email = userDtoToUpdate.email;
        activeUser.isActive= userDtoToUpdate.isActive;
        activeUser.UserProfileId = userDtoToUpdate.UserProfileId;
        activeUser.profile = new UserProfile()
        {
            FirstName = userDtoToUpdate.FirstName,
            LastName = userDtoToUpdate.LastName,
            personalNumber = userDtoToUpdate.PersonalNumber,
        };

        await _unitOfWorkRepository.UserRepository.UpdateAsync(activeUser);
        await _unitOfWorkRepository.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int id)
    {
        var existingUser = await _unitOfWorkRepository.UserRepository.GetByIdAsync(id);
        if (existingUser == null) throw new NoUsersException();
        var existingProfileToUpdate = await _unitOfWorkRepository.UserProfileRepository.
            FindAsync(x => x.Id == existingUser.UserProfileId);
        if(existingProfileToUpdate != null)
        {
            existingProfileToUpdate.FirstName = null;
            existingProfileToUpdate.LastName = null;
            existingProfileToUpdate.personalNumber = null;

            await _unitOfWorkRepository.UserProfileRepository.UpdateAsync(existingProfileToUpdate);
            await _unitOfWorkRepository.SaveChangesAsync();
        }
        await _unitOfWorkRepository.UserRepository.DeleteAsync(existingUser);
        await _unitOfWorkRepository.SaveChangesAsync();

    }
}
