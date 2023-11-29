using UserProjectTosend.Domain.Abstractions;
using UserProjectTosend.Domain.DTOs;
using UserProjectTosend.Domain.Exceptions;
using UserProjectToSend.Apliaction.AbstractionServices;

namespace UserProjectToSend.Apliaction.Services;

public class AuthorizationService:IAuthorizationService
{
    private readonly IUnitOfWorkRepository _unitOfWorkRepository;
    private readonly ISecurityService _securityService;
    public AuthorizationService(IUnitOfWorkRepository unitOfWorkRepository, ISecurityService securityService)
    {
        _unitOfWorkRepository = unitOfWorkRepository;
        _securityService = securityService;
    }
    public async Task<string> Login(userForLoginDTO userDTO)
    {
            var userLoginConformation = await _unitOfWorkRepository.UserRepository.FindAsync(x => x.userName == userDTO.username);
            if (userLoginConformation == null) throw new IncorrectPasswordException();
            var passwordHash = _securityService.GetPasswordHash(userDTO.password);

            if (passwordHash != userLoginConformation.password) throw new IncorrectPasswordException();
            var res = _securityService.CreateToken(userLoginConformation.Id);
            return res;
    }
}
