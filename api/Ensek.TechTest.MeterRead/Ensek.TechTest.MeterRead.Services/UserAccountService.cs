using Ensek.TechTest.MeterRead.Domain.Models;
using Ensek.TechTest.MeterRead.Repositories.Interfaces;
using Ensek.TechTest.MeterRead.Services.Interfaces;

namespace Ensek.TechTest.MeterRead.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public UserAccountService(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<IList<UserAccountDto>> GetAllUsersAsync()
        {
            return await _userAccountRepository.GetAllUsersAsync();
        }

        public async Task<UserAccountDto> GetUserAsync(int accountId)
        {
            return await _userAccountRepository.GetUserAccountAsync(accountId);
        }

        public async Task<UserAccountDto> AddUserAsync(UserAccountDto user)
        {
            return await _userAccountRepository.CreateUserAsync(user);
        }

        public async Task<UserAccountDto> UpdateUserAsync(int userId, UserAccountDto user)
        {
            return await _userAccountRepository.UpdateUserAsync(userId, user);
        }

        public async Task<UserAccountDto> FindUserByIdAsync(int id)
        {
            return await _userAccountRepository.FindUserByIdAsync(id);
        }

        public async Task DeleteUserByIdAsync(int id)
        {
            await _userAccountRepository.DeleteUserByIdAsync(id);
        }
    }
}
