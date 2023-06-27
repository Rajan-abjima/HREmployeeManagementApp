using AutoMapper;
using Management.Core.Models;
using Management.Entities.AttendanceEntities;

namespace Management.Mapping.Profiles;
public class AttendanceProfile : Profile
{
    public AttendanceProfile()
    {
        CreateMap<DayCheckIn,AttendanceModel>();
        CreateMap<AttendanceModel, DayCheckIn>();
        CreateMap<DayCheckOut,AttendanceModel>();
        CreateMap<AttendancePersonal, AttendanceModel>();
        CreateMap<AttendanceModel, AttendancePersonal>();
    }
}
