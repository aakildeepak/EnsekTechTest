using Ensek.TechTest.MeterRead.Domain.Models;

namespace Ensek.TechTest.MeterRead.Repositories.Interfaces
{
    public interface IUserAccountRepository
    {
        Task<UserAccountDto> GetUserAccountAsync(int accountId);
        Task<IList<UserAccountDto>> GetAllUsersAsync();
        Task<UserAccountDto> CreateUserAsync(UserAccountDto user);
        Task<UserAccountDto> UpdateUserAsync(int id, UserAccountDto user);
        Task<UserAccountDto> FindUserByIdAsync(int id);
        Task DeleteUserByIdAsync(int id);
    }
}
