using Dapper;
using Management.Application.Interfaces;
using Management.Enities.EmployeeEntities;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Management.Infrastructure.Repositories;
public class EmployeeRepository : IEmployeeRepository
{
    private readonly IConfiguration _configuration;

    public EmployeeRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<int> AddAsync(EmployeePersonal employee)
    {
        employee.JoiningDate = DateTime.UtcNow;
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            connection.Open();
            var result = await connection.ExecuteAsync("spEmployee_InsertByEmployee",employee,commandType: CommandType.StoredProcedure);
            return result;
        }
    }

    public async Task<EmployeePersonal> GetByIdAsync(int id)
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            connection.Open();
            var result = await connection.QueryFirstOrDefaultAsync<EmployeePersonal>("spEmployee_InsertByEmployee", new {EmployeeID = id}, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
