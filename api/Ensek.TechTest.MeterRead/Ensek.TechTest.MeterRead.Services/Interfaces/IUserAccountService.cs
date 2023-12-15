using Ensek.TechTest.MeterRead.Domain.Models;

namespace Ensek.TechTest.MeterRead.Services.Interfaces
{
    public interface IUserAccountService
    {
        Task<IList<UserAccountDto>> GetAllUsersAsync();
        Task<UserAccountDto> GetUserAsync(int accountId);
        Task<UserAccountDto> AddUserAsync(UserAccountDto user);
        Task<UserAccountDto> UpdateUserAsync(int accountId, UserAccountDto user);
        Task<UserAccountDto> FindUserByIdAsync(int id);
        Task DeleteUserByIdAsync(int id);
    }
}
