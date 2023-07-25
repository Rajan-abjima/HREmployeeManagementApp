using Dapper;
using Management.Application.Interfaces;
using Management.Core.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

public class ApplicantRepository :IApplicantRepository
{
    private readonly IConfiguration _configuration;

    public ApplicantRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string> ApplicantRegistration(ApplicantModel applicantCredentials)
    {
        try
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("default")))
            {
                connection.Open();
                var param = new DynamicParameters();

                param.Add("@ApplicantMasterid", applicantCredentials.ApplicantMasterid);
                param.Add("@FullName", applicantCredentials.FullName);
                param.Add("@ContactNumber", applicantCredentials.ContactNumber);
                param.Add("@Gender", applicantCredentials.Gender);
                param.Add("@TotalExperience", applicantCredentials.TotalExperience);
                param.Add("@RelevantExperience", applicantCredentials.RelevantExperience);
                param.Add("@AppliedForPosition", applicantCredentials.AppliedForPosition);
                param.Add("@TechnicalSkills", applicantCredentials.TechnicalSkills);
                param.Add("@HighestQualification", applicantCredentials.HighestQualification);
                param.Add("@YearOfPassing", applicantCredentials.YearOfPassing);
                param.Add("@CurrentCtc", applicantCredentials.CurrentCtc);
                param.Add("@ExpectedCtc", applicantCredentials.ExpectedCtc);
                param.Add("@NoticePeriodDays", applicantCredentials.NoticePeriodDays);
                param.Add("@StatusofEmployment", applicantCredentials.StatusofEmployment);
                param.Add("@Email", applicantCredentials.Email);
                param.Add("@CurrentLocation", applicantCredentials.CurrentLocation);
                param.Add("@WillingToRelocate", applicantCredentials.WillingToRelocate);
                param.Add("@CurrentCompany", applicantCredentials.CurrentCompany);
                param.Add("@RegistrationSuccess","1", DbType.Int32, direction: ParameterDirection.Output);

                await connection.ExecuteAsync("usp_InsertApplicantMaster", param, commandType: CommandType.StoredProcedure);
                var registrationSuccess = param.Get<int>("@RegistrationSuccess");

                if (registrationSuccess == 1)
                {
                    return "RegistrationSuccess";
                }
                else
                {
                    return "Invalid credentials. Please register.";
                }
            }
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }
}
