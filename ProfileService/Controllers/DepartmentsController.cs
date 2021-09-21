using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProfileService.Services.Departments;

namespace ProfileService.Controllers
{
	[Route("api/[controller]")]
	public class DepartmentsController : Controller
	{
		private readonly IDepartmentService _departmentService;

		public DepartmentsController(IDepartmentService departmentService)
		{
			_departmentService = departmentService;
		}

		[HttpGet]
		public IActionResult GetDepartments()
		{
			var departments = _departmentService.GetDepartments();
			return Ok(	
				departments.Select(
					department => new
					{
						id = department.Id,
						title = department.Title
					}));
		}
	}
}