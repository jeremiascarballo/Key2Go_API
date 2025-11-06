using Domain.Entity;

namespace Application.Abstraction
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmail(string email);
    }
}
