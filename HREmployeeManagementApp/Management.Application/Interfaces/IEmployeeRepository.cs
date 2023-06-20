using Management.Entities.EmployeeEntities;

namespace Management.Application.Interfaces;
public interface IEmployeeRepository
{
    Task<EmployeePersonal> GetByIdAsync(int id);
    Task<ViewEmployeeCredentials> AddAsync(EmployeePersonal employee);
    Task<EmployeeSignUp> AddCredentialsAsync(EmployeeSignUp employee);
    Task<int> CheckEmployeeAysnc(EmployeeLogin employeeLogin);
}