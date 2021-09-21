using System.Threading.Tasks;

namespace UserService.Database.Repositories
{
	public interface IRepository<TEntity>
	{
		Task<TEntity?> GetEntityAsync(int id);

		void UpdateEntity(TEntity updatingEntity);

		Task CreateEntityAsync(TEntity createdEntity);

		void DeleteEntity(TEntity deletingEntity);

		Task SaveChangesAsync();
	}
}