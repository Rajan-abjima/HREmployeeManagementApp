using Microsoft.AspNetCore.Mvc;

namespace EmployeeHandler.Controllers;
public class InterviewFormController : Controller
{
	public IActionResult InterviewerForm()
	{
		return View();
	}
}
