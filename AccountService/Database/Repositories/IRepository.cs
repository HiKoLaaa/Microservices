using System.Threading.Tasks;

namespace AccountService.Database.Repositories
{
	public interface IRepository<TEntity>
	{
		Task<TEntity?> GetEntityAsync(int id);

		void UpdateEntity(TEntity updatingAccount);

		Task CreateEntityAsync(TEntity createdAccount);

		void DeleteEntity(TEntity deletingAccount);

		Task SaveChangesAsync();
	}
}