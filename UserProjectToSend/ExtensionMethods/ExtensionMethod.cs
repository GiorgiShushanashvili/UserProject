using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserProjectToSend.Dal;

namespace UserProjectToSend.ExtensionMethods;

public static class ExtensionMethod
{
    public static IServiceCollection AddUserProjectDbContext(this IServiceCollection service, IConfiguration configuration) =>
        service.AddDbContext<UserProjectDbContext>(config 
            => config.UseSqlServer(configuration.GetConnectionString("NewDatabase")));
}
