﻿using Management.Application.Interfaces;
using Management.Infrastructure.Repositories;
using Management.Mapping.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Management.Infrastructure;

/// <summary>
/// Here are all the services related to the MVC that are needed to be registed in Program file
/// This is a service extention method
/// </summary>
public static class ServiceRegistration
{
    public static void AddInfrastructure (this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(EmployeeProfile));
        services.AddAutoMapper(typeof(AttendanceProfile));
        services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        services.AddTransient<IAttendanceRepository, AttendanceRepository>();

    }
}
