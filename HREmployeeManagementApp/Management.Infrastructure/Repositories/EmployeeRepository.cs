using Dapper;
using Management.Application.Interfaces;
using Management.Entities.EmployeeEntities;
using Management.ViewModel;
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
    
    public async Task<ViewEmployeeCredentials> AddAsync(EmployeePersonal employee)
    {
        
        employee.JoiningDate = DateTime.UtcNow;
        employee.AdminStatus = false;
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
            param.Add("@FirstNameOutput", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
            param.Add("@LastNameOutput", dbType: DbType.String, direction: ParameterDirection.Output, size: 50);
            param.Add("@EmployeeIdentity", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 50);
            var result = await connection.ExecuteAsync("spEmployee_InsertByEmployee", param, commandType: CommandType.StoredProcedure);

            int EmployeeIdentity = param.Get<int>("@EmployeeIdentity");
            string currentFirstName = param.Get<string>("@FirstNameOutput");
            string currentLastName = param.Get<string>("@LastNameOutput");

            var currentEmployeeCredentials = new ViewEmployeeCredentials
            {
                EmployeeID = EmployeeIdentity,
                FirstName = currentFirstName,
                LastName = currentLastName
            };

            return currentEmployeeCredentials;
        }  
    }

    public async Task<EmployeeSignUp> AddCredentialsAsync(EmployeeSignUp employee)
    {        
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            connection.Open();
            var param = new DynamicParameters();
            param.Add("@EmployeeID", employee.EmployeeID);
            param.Add("@FirstName", employee.FirstName);
            param.Add("@LastName", employee.LastName);
            param.Add("@UserName", employee.UserName);
            param.Add("@Password", employee.Password);
            param.Add("@IsValid", employee.IsValid);
            var result = await connection.QueryFirstOrDefaultAsync<string>("spCredentials_Insert", param: param, commandType: CommandType.StoredProcedure);


            if (result == "true")
            {
                var currentEmployee = new EmployeeSignUp
                {
                    EmployeeID = employee.EmployeeID,
                    UserName = employee.UserName
                };
                return currentEmployee;
            }
            else
            {
                return new EmployeeSignUp();
            }
           
        }
    }

	public async Task<int> CheckEmployeeAysnc(EmployeeLogin employeeLogin)
	{
		using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
		{
			connection.Open();

			var param = new
			{
				username = employeeLogin.UserName,
				password = employeeLogin.Password,
			};

			var result = await connection.QueryFirstOrDefaultAsync<int>(
				"EmployeeLogin",
				param,
				commandType: CommandType.StoredProcedure);

			return result;
		}
	}


    public async Task<IReadOnlyList<EmployeeAdmin>> GetAllEmployeesAsync()
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            connection.Open();
            var employees = await connection.QueryAsync<EmployeeAdmin>("spEmployee_GetAll", commandType: CommandType.StoredProcedure);

            return employees.ToList();
        }
    }


    public async Task<EmployeePersonal> GetByIdAsync(int employeeID)
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
        {
            connection.Open();
            var result = await connection.QuerySingleOrDefaultAsync<EmployeePersonal>
                        ("spEmployee_GetByID", new { EmployeeID = employeeID }, commandType: CommandType.StoredProcedure);
            return result;
        }
    }

    
}
