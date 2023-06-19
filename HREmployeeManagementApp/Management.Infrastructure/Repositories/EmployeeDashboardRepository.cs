using Dapper;
using Management.Application.Interfaces;
using Management.Entities.EmployeeEntities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infrastructure.Repositories;
public class EmployeeDashboardRepository : IEmployeeDashboardRepository
{
    private readonly IConfiguration _configuration;

    public EmployeeDashboardRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<EmployeePersonal> GetByIDAsync(int employeeID)
    {
        
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            connection.Open();
            var result = await connection.QuerySingleOrDefaultAsync<EmployeePersonal>
                        ("spEmployee_GetByID", new { EmployeeID = employeeID}, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
