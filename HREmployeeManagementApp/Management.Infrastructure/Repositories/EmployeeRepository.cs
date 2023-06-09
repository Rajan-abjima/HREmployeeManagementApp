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
        try
        {
            employee.JoiningDate = DateTime.UtcNow;
            employee.AdminStatus = true;
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@FirstName", employee.FirstName);
                param.Add("@LastName", employee.LastName);
                param.Add("@Gender", employee.Gender);
                param.Add("@DateOfBirth", employee.DateOfBirth);
                param.Add("@Address", employee.Address);
                param.Add("@Contact", employee.Contact);
                param.Add("@Designation", employee.Designation);
                param.Add("@SignInApprovedBy", employee.SignInApprovedBy);
                param.Add("@JoiningDate", employee.JoiningDate);
                param.Add("@AdminStatus", employee.AdminStatus);
                var result = await connection.ExecuteAsync("spEmployee_InsertByEmployee", param, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        catch (Exception ex) { throw ex; }
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
