using Microsoft.Extensions.DependencyInjection;
using UserProjectTosend.Domain.Abstractions;
using UserProjectToSend.Apliaction.AbstractionServices;
using UserProjectToSend.Apliaction.Services;
using UserProjectToSend.Dal.Repository;

namespace UserProjectToSend.CrossCutting;

public static class IoCRegister
{
    public static IServiceCollection AddCommonServices(this IServiceCollection services)
    {
        AddServices(services);
        AddRepositories(services);
        AddCorsService(services);
        return services;
    }

    private static IServiceCollection AddServices(IServiceCollection services)
    {
        services.AddScoped<IAuthorizationService, AuthorizationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserProfileService, UserProfileService>();
        services.AddScoped<ISecurityService, SecurityService>();
        return services;
    }

    private static IServiceCollection AddRepositories(IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserProfileRepository, UserProfileRepository>();
        services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
        return services;
    }
    private static IServiceCollection AddCorsService(IServiceCollection services)
    {
        services.AddCors((opt) =>
        {
            opt.AddPolicy("DevCors", (corsBuilder) =>
            {
                corsBuilder.WithOrigins("http://localhost:4200", "http://localhost:3000", "http://localhost:8000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
        });
        return services;
    }
}
