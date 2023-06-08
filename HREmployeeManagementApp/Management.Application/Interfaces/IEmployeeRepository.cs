using Management.Enities.EmployeeEntities;

namespace Management.Application.Interfaces;
public interface IEmployeeRepository
{
    Task<EmployeePersonal> GetByIdAsync(int id);
    Task<int> AddAsync(EmployeePersonal employee);
}