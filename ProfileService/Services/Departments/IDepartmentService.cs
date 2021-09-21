using System.Collections;
using System.Collections.Generic;
using ProfileService.Models;

namespace ProfileService.Services.Departments
{
	public interface IDepartmentService
	{
		IEnumerable<Department> GetDepartments();
	}
}