using System.Collections.Generic;
using System.Threading.Tasks;
using ProfileService.Models;

namespace ProfileService.Database.Repositories.Departments
{
	internal class DepartmentRepository : IRepository<Department>
	{
		private readonly ProfileDbContext _profileDbContext;

		public DepartmentRepository(ProfileDbContext profileDbContext)
		{
			_profileDbContext = profileDbContext;
		}

		public async Task<Department?> GetEntityAsync(int id) => await _profileDbContext.Departments.FindAsync(id);

		public IEnumerable<Department> GetEntities() => _profileDbContext.Departments;

		public void UpdateEntity(Department updatingEntity) => _profileDbContext.Departments.Update(updatingEntity);

		public async Task CreateEntityAsync(Department createdEntity) =>
			await _profileDbContext.Departments.AddAsync(createdEntity);

		public void DeleteEntity(Department deletingEntity) => _profileDbContext.Departments.Remove(deletingEntity);

		public async Task SaveChangesAsync() => await _profileDbContext.SaveChangesAsync();
	}
}