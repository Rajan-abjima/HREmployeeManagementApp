using Management.Entities.InterviewEntities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeHandler.Controllers;
public class InterviewFormController : Controller
{
	public IActionResult InterviewerForm()
	{
		var response = new Interview();
		return View(response);
	}
}
