using Management.Entities.EmployeeEntities;
using Management.ViewModel;

namespace Management.Application.Interfaces;
public interface IEmployeeRepository
{
    Task<IReadOnlyList<EmployeeAdmin>> GetAllEmployeesAsync();
    Task<EmployeePersonal> GetByIdAsync(int employeeID);
    Task<ViewEmployeeCredentials> AddAsync(EmployeePersonal employee);
    Task<EmployeeSignUp> AddCredentialsAsync(EmployeeSignUp employee);
    Task<int> CheckEmployeeAysnc(EmployeeLogin employeeLogin);
}