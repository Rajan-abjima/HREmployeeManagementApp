using Management.Entities.AdminEntities;
using Management.Entities.EmployeeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.ViewModel;
public class LoginViewModel
{
    public EmployeeLogin EmployeeLogin = new EmployeeLogin();
    public AdminLogin AdminLogin = new AdminLogin();
}
