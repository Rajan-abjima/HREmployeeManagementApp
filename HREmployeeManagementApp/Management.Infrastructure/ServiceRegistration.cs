using Management.Mapping.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Management.Infrastructure;

/// <summary>
/// Here are all the services related to the MVC that are needed to be registed in Program file
/// This is service extention method
/// </summary>
public static class ServiceRegistration
{
    public static void AddInfrastructure (this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(EmployeeProfile));
    }
}
