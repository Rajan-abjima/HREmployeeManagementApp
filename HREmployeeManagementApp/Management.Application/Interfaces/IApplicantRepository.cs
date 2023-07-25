using Management.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Interfaces;

public interface IApplicantRepository
{

    Task<string> ApplicantRegistration(ApplicantModel applicantCredentials);
}
