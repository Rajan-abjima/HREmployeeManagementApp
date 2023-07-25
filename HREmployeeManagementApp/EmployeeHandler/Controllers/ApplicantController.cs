
using Management.Application.Interfaces;
using Management.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeHandler.Controllers
{
    public class ApplicantController : Controller
    {
        private readonly IApplicantRepository _applicantRepository;
        public ApplicantController(IApplicantRepository applicantRepository)
        {
          
            _applicantRepository = applicantRepository;
            
        }
        public IActionResult ApplicantRegistration()
        {
            return View();
        }

        public async Task<IActionResult> ApplicantRegis(ApplicantModel applicantCredentials)
        {
            if (ModelState.IsValid)
            {
                var newapplicant = await _applicantRepository.ApplicantRegistration(applicantCredentials);

                if (newapplicant == "RegistrationSuccess")
                {
                    TempData["LoginMessage"] = "Login Successful";
                    return RedirectToAction("Index", "Home");
                }
                else
                {

                    TempData["LoginMessage"] = "Invalid Field";
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
               
                throw new Exception("Invalid model state.");

            }
        }
    }
}
