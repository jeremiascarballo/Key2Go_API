using Domain.Entity;

namespace Application.Abstraction
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}