using Management.Core.Models;
using Management.Enities.EmployeeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Interfaces;
public interface IEmployeeRepository : ILoadRepository<EmployeeForEmployee>,
                                       ISaveRepository<EmployeeForAdmin>
{

}