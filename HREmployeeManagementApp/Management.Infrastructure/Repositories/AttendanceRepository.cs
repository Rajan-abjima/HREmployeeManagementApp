using Dapper;
using Management.Application.Interfaces;
using Management.Entities.AttendanceEntities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        dayCheckIn.Date = DateTime.UtcNow;
        TimeSpan currentTime = DateTime.Now.TimeOfDay;
        dayCheckIn.CheckIn = currentTime;
        using (var connection = new SqlConnection(_configuration.GetConnectionString("default")))
        {
            connection.Open();
            var param = new DynamicParameters();
            param.Add("@EmployeeID", dayCheckIn.EmployeeID);
            param.Add("@Date", dayCheckIn.Date);
            param.Add("@Status", dayCheckIn.Status);
            param.Add("@CheckIn", dayCheckIn.CheckIn);

            var result = await connection.QueryFirstOrDefaultAsync<string>("spAttendance_CheckIn", param: param, commandType: CommandType.StoredProcedure);

            int AttendanceIdentity = param.Get<int>("@AttendanceIdentity");
            int EmployeeIdentity = param.Get<int>("@EmployeeID");
            
            var currentEmployeeCheckIn = new DayCheckIn
            {
                AttendanceID = AttendanceIdentity,
                EmployeeID = EmployeeIdentity,
                CheckIn = currentTime                    
            };
            return currentEmployeeCheckIn;
        }
    }

    public async Task<int> UpdateCheckOutAsync(DayCheckOut dayCheckOut)
    {
        using (var connection = new SqlConnection(_configuration.GetConnectionString("default")))
        {
            connection.Open();
            var result = await connection.ExecuteAsync("spAttendance_CheckOut", dayCheckOut.AttendanceID, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
