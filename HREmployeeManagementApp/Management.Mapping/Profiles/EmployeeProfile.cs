using AutoMapper;
using Management.Core.Models;
using Management.Enities.EmployeeEntities;

namespace Management.Mapping.Profiles;
public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<EmployeePersonal, EmployeeModel>();
        CreateMap<EmployeeModel, EmployeePersonal>();
        CreateMap<EmployeeModel, EmployeeLogin>();
        CreateMap<EmployeeLogin, EmployeeModel>();
    }
}
