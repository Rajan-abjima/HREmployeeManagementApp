using Dapper;
using Management.Application.Interfaces;
using Management.Entities.AttendanceEntities;
using Management.Entities.EmployeeEntities;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Runtime.InteropServices;

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
        try
        {
            dayCheckIn.Status = "Present";
            dayCheckIn.Date = DateTime.UtcNow.Date;
            DateTime currentTime = DateTime.Now;
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
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public async Task<DayCheckOut> UpdateCheckOutAsync(DayCheckOut dayCheckOut)
    {
        try
        {
            DateTime currentTime = DateTime.Now;
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
        catch (Exception ex)
        {

            throw ex;
        }
    }


    public async Task<AttendancePersonal> GetExactAttendanceByEmployeeIDAsync(int employeeID)
    {
        try
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("default")))
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@EmployeeID", employeeID);
                var result = await connection.QuerySingleAsync<AttendancePersonal>("spAttendance_GetByEmployeeID", param, commandType: CommandType.StoredProcedure);

                return result;
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }        
    }

    public async Task<IEnumerable<AttendancePersonal>> GetAttendancePersonalAsync(int employeeID)
    {
        try
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("default")))
            {
                connection.Open();
                var result = await connection.QueryAsync<AttendancePersonal>("spAttendance_GetAllByID", new { EmployeeID = employeeID }, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public async Task<IEnumerable<AttendanceAdmin>> GetAttendanceAdminByIDAsync(int employeeID)
    {
        try
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("default")))
            {
                connection.Open();
                var result = await connection.QueryAsync<AttendanceAdmin>("spAttendance_GetAllByID", new { EmployeeID = employeeID }, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }


	                            ////////////////////////UNUSED TILL NOW/////////////////////////////////
	public async Task<IEnumerable<AttendanceAdmin>> GetAttendanceAdminByIDAndDateAsync(int employeeId, DateTime date)
    {
        try
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("default")))
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@EmployeeId", employeeId);
                param.Add("@Date", date);
                var result = await connection.QueryAsync<AttendanceAdmin>("spAttendance_GetAllByDate", param, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
		catch (Exception ex)
		{

			throw ex;
		}
	}

    public async Task<AttendancePersonal> GetAttendanceByAttendanceID(int attendanceID)
    {
        try
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("default")))
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<AttendancePersonal>("spAttendance_SingleByID", new { AttendanceID = attendanceID }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
		catch (Exception ex)
		{

			throw ex;
		}
	}

    public async Task<EmployeeRegularization> RegularizationRequestAsync(EmployeeRegularization regularization)
    {
        try
        {
            regularization.DateOfRequest = DateTime.Now;
            using (var connection = new SqlConnection(_configuration.GetConnectionString("default")))
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@AttendanceID", regularization.AttendanceID);
                param.Add("@EmployeeID", regularization.EmployeeID);
                param.Add("@RegularizeDate", regularization.RegularizeDate);
                param.Add("@CheckedIn", regularization.CheckedIn);
                param.Add("@CheckedOut", regularization.CheckedOut);
                param.Add("@DateOfRequest", regularization.DateOfRequest);
                param.Add("@AppliedCheckIn", regularization.AppliedCheckIn);
                param.Add("@AppliedCheckOut", regularization.AppliedCheckOut);
                param.Add("@Reason", regularization.Reason);
                param.Add("@RegularizeIdentity", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await connection.ExecuteAsync("spRegularization_InsertRequest", param, commandType: CommandType.StoredProcedure);
                var regularizeIdentity = param.Get<int>("@RegularizeIdentity");
                var employeeID = param.Get<int>("@EmployeeID");

                EmployeeRegularization currentRegularizeDetails = new()
                {
                    RegularizeID = regularizeIdentity,
                    EmployeeID = employeeID
                };

                return currentRegularizeDetails;
            }
        }
		catch (Exception ex)
		{

			throw ex;
		}
	}

    public async Task<IReadOnlyList<LeavePersonal>> GetAllLeaveRequestsByID(int employeeID)
    {
        try
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@employeeID", employeeID);
                var result = await connection.QueryAsync<LeavePersonal>("spLeaveRecord_GetByID", param, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
		catch (Exception ex)
		{

			throw ex;
		}
	}

	public async Task<LeavePersonal> LeaveRequestAsync(LeavePersonal leave)
    {
        try
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@EmployeeID", leave.EmployeeID);
                param.Add("@FromDate", leave.DateFrom);
                param.Add("@ToDate", leave.ToDate);
                param.Add("@DateOfRequest", leave.DateOfRequest);
                param.Add("@Reason", leave.Reason);
                param.Add("@LeaveRequestID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await connection.ExecuteAsync("spLeaveRecord_InsertRequest", param, commandType: CommandType.StoredProcedure);

                var leaveRequestId = param.Get<int>("@LeaveRequestID");

                LeavePersonal leavePersonal = new()
                {
                    LeaveID = leaveRequestId
                };

                return leavePersonal;
            }
        }
		catch (Exception ex)
		{

			throw ex;
		}
	}

    public async Task<IReadOnlyList<LeaveAdmin>> PendingLeaveRequestAsync()
    {
        try
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                connection.Open();
                var result = await connection.QueryAsync<LeaveAdmin>("spLeaveRecord_ListOfPendings", commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
		catch (Exception ex)
		{

			throw ex;
		}
	}

    public async Task<IReadOnlyList<RegularizationAdmin>> PendingRegularizationRequestAsync()
    {
        try
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                connection.Open();
                var result = await connection.QueryAsync<RegularizationAdmin>("spRegularization_ListOfPendings", commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
		catch (Exception ex)
		{

			throw ex;
		}
	}


    public async Task<IEnumerable<LeaveAdmin>> GetAllLeavesAsync()
    {
        try
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                connection.Open();
                var result = await connection.QueryAsync<LeaveAdmin>("spLeaveRecord_GetAll", commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
		catch (Exception ex)
		{

			throw ex;
		}
	}

    public async Task<LeaveAdmin> GetLeaveByID(int leaveID)
    {
        try
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<LeaveAdmin>("spLeaveRecord_GetByID", param: new { leaveID }, commandType: CommandType.StoredProcedure);

                return result;
            }
        }
		catch (Exception ex)
		{

			throw ex;
		}
	}

    public async Task<int> UpdateLeaveRequest(LeaveAdmin leaveAdmin)
    {
        try
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@AdministeredBy", leaveAdmin.AdministeredBy);
                param.Add("@ApprovalStatus", leaveAdmin.ApprovalStatus);
                param.Add("@Comment", leaveAdmin.Comment);
                param.Add("@leaveID", leaveAdmin.LeaveID);
                var result = await connection.ExecuteAsync("spLeaveRecord_Decision", param, commandType: CommandType.StoredProcedure);

                return result;
            }
        }
		catch (Exception ex)
		{

			throw ex;
		}
	}


    public async Task<IEnumerable<RegularizationAdmin>> GetAllRegularizationsAsync()
    {
        try
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                connection.Open();
                var result = await connection.QueryAsync<RegularizationAdmin>("spRegularization_GetAll", commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public async Task<RegularizationAdmin> GetRegualrizationByID(int regularizeID)
    {
        try
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<RegularizationAdmin>("spRegularization_GetByID", param: new { regularizeID }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
		catch (Exception ex)
		{

			throw ex;
		}
	}

    public async Task<int> UpdateRegularizationRequest(RegularizationAdmin regularizationAdmin)
    {
        try
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@regularizedBy", regularizationAdmin.RegularizedBy);
                param.Add("@decision", regularizationAdmin.Decision);
                param.Add("@comment", regularizationAdmin.Comment);
                param.Add("@regularizeID", regularizationAdmin.RegularizeID);
                var result = await connection.ExecuteAsync("spRegularization_Decision", param, commandType: CommandType.StoredProcedure);

                return result;
            }
        }
		catch (Exception ex)
		{

			throw ex;
		}
	}
}
