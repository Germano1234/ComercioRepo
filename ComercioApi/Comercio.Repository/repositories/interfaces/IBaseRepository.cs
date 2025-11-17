namespace Comercio.Repository.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class{
        Task<T?> GetByIdAsync(long id);
        Task<List<T>> GetAllASync();
        Task<T> AddAsync(T entidade);
        Task<T> UpdateAsync(T entidade);
        Task DeleteAsync(T entidade);
    }
}