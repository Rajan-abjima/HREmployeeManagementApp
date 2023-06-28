using Management.Entities.AttendanceEntities;
using Management.Entities.EmployeeEntities;

namespace Management.ViewModel;
public class PersonalDetails
{
    public DayCheckIn CheckIn = new DayCheckIn();
    public EmployeePersonal EmployeePersonal = new EmployeePersonal();
    public DayCheckOut CheckOut = new DayCheckOut();
    public AttendancePersonal AttendancePersonal = new AttendancePersonal();
}
