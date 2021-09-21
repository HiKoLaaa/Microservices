using System.Collections.Generic;
using ProfileService.Database.Repositories;
using ProfileService.Models;

namespace ProfileService.Services.Departments
{
	internal class DepartmentService : IDepartmentService
	{
		private readonly IRepository<Department> _departmentRepository;

		public DepartmentService(IRepository<Department> departmentRepository)
		{
			_departmentRepository = departmentRepository;
		}

		public IEnumerable<Department> GetDepartments() => _departmentRepository.GetEntities();
	}
}