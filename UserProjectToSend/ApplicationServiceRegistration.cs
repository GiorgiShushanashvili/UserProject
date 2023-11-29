using AutoMapper;
using System.Reflection;
using UserProjectToSend.Apliaction.Mapper;

namespace UserProjectToSend;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddAplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(cnfg =>
        {
            cnfg.AddProfile<UserProfileMapper>();
        },
        Assembly.GetExecutingAssembly());
        return services;
    }
}
