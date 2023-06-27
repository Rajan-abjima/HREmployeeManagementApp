using Dapper;
using Management.Application.Interfaces;
using Management.Entities.AttendanceEntities;
using Management.Entities.EmployeeEntities;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Management.Infrastructure.Repositories;
public class AttendanceRepository : IAttendanceRepository
{
    private readonly IConfiguration _configuration;

    public AttendanceRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<DayCheckIn> AddCheckInAsync(DayCheckIn dayCheckIn)
    {
        dayCheckIn.Status = "Present";
        dayCheckIn.Date = DateTime.UtcNow.Date;
        TimeSpan currentTime = DateTime.Now.TimeOfDay;
        dayCheckIn.CheckIn = currentTime;
        using (var connection = new SqlConnection(_configuration.GetConnectionString("default")))
        {
            connection.Open();
            var param = new DynamicParameters();
            param.Add("@EmployeeID", dayCheckIn.EmployeeID);
            param.Add("@FirstName", dayCheckIn.FirstName);
            param.Add("@LastName", dayCheckIn.LastName);
            param.Add("@Date", dayCheckIn.Date);
            param.Add("@Status", dayCheckIn.Status);
            param.Add("@CheckIn", dayCheckIn.CheckIn);
			param.Add("@AttendanceIdentity", dbType: DbType.Int32, direction: ParameterDirection.Output);

			var result = await connection.ExecuteAsync("spAttendance_CheckIn", param, commandType: CommandType.StoredProcedure);

            int AttendanceIdentity = param.Get<int>("@AttendanceIdentity");
            
            var currentEmployeeCheckIn = new DayCheckIn
            {
                AttendanceID = AttendanceIdentity,
                CheckIn = currentTime
            };
            return currentEmployeeCheckIn;
        }
    }

    public async Task<DayCheckOut> UpdateCheckOutAsync(DayCheckOut dayCheckOut)
    {
		TimeSpan currentTime = DateTime.Now.TimeOfDay;
		dayCheckOut.CheckOut = currentTime;
		using (var connection = new SqlConnection(_configuration.GetConnectionString("default")))
        {
            connection.Open();
			var param = new DynamicParameters();
			param.Add("@AttendanceID", dayCheckOut.AttendanceID);
			param.Add("@CheckOut", dayCheckOut.CheckOut);
			var result = await connection.ExecuteAsync("spAttendance_CheckOut", param: param, commandType: CommandType.StoredProcedure);

            var currentEmployeeCheckOut = new DayCheckOut
            {
                AttendanceID = dayCheckOut.AttendanceID,
                EmployeeID = dayCheckOut.EmployeeID,
                CheckOut = currentTime
            };
            return currentEmployeeCheckOut;
        }
    }


    public async Task<AttendancePersonal> GetAttendanceByEmployeeIDAsync(int employeeID)
    {
        var Date = DateTime.Now;
        using (var connection = new SqlConnection(_configuration.GetConnectionString("default")))
        {
            connection.Open();
            var param = new DynamicParameters();
            param.Add("@EmployeeID", employeeID);
            param.Add("@Date", Date);
            var result = await connection.QuerySingleAsync<AttendancePersonal>
                        ("spAttendance_GetByEmployeeID", param, commandType: CommandType.StoredProcedure);
        }
        throw new NotImplementedException();
    }


}
