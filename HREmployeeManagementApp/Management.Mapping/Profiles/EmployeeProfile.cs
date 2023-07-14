using AutoMapper;
using Management.Core.Models;
using Management.Entities.AttendanceEntities;
using Management.Entities.EmployeeEntities;

namespace Management.Mapping.Profiles;
public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<EmployeePersonal, EmployeeModel>();
        CreateMap<EmployeeModel, EmployeePersonal>();        
        CreateMap<EmployeeRegistration, EmployeeLogin>();
        CreateMap<EmployeeSignUp, EmployeeRegistration>();
        CreateMap<EmployeeModel,EmployeeAdmin>();
        CreateMap<AttendanceModel, AttendanceAdmin>();
    }
}
