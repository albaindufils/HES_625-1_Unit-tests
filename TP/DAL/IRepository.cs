
namespace DAL
{
    public interface IRepository<TEntity, TKey>
	{
		TEntity GetById(TKey key);
	}
}
