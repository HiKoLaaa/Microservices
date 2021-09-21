using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfileService.Database.Repositories
{
	public interface IRepository<TEntity>
	{
		Task<TEntity?> GetEntityAsync(int id);

		IEnumerable<TEntity> GetEntities();

		void UpdateEntity(TEntity updatingEntity);

		Task CreateEntityAsync(TEntity createdEntity);

		void DeleteEntity(TEntity deletingEntity);

		Task SaveChangesAsync();
	}
}