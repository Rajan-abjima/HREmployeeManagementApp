using Management.Entities.EmployeeEntities;

namespace Management.Application.Interfaces;
public interface IEmployeeRepository
{
    Task<EmployeePersonal> GetByIdAsync(int id);
    Task<ViewEmployeeCredentials> AddAsync(EmployeePersonal employee);
    Task<int> AddCredentialsAsync(EmployeeSignUp employee);
    Task<bool> CheckEmployeeAysnc(EmployeeLogin employeeLogin);
}