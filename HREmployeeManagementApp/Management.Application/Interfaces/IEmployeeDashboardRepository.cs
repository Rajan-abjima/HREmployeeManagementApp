using Management.Entities.EmployeeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Interfaces;
public interface IEmployeeDashboardRepository
{
    Task<EmployeePersonal> GetByIDAsync(int employeeID);
}
