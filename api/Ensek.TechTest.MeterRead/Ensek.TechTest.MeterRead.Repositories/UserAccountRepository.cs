using Ensek.TechTest.MeterRead.Data.DbContexts;
using Ensek.TechTest.MeterRead.Data.Entities;
using Ensek.TechTest.MeterRead.Domain.Models;
using Ensek.TechTest.MeterRead.Repositories.Interfaces;
using Ensek.TechTest.MeterRead.Repositories.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Ensek.TechTest.MeterRead.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly MeterReadingContext _context;

        public UserAccountRepository(MeterReadingContext context)
        {
            _context = context;
        }

        public async Task<IList<UserAccountDto>> GetAllUsersAsync()
        {
            var users = await _context.UserAccount
                                    .AsNoTracking()
                                    .ToListAsync();

            return users.Select(u => u.MapToDomain()).ToList();
        }

        public async Task<UserAccountDto> GetUserAccountAsync(int accountId)
        {
            var userAccount = await _context.UserAccount.AsNoTracking()
                                .Where(user => user.AccountId == accountId)
                                .SingleOrDefaultAsync();

            return ProcessUserAccount(userAccount);
        }

        public async Task<UserAccountDto> CreateUserAsync(UserAccountDto user)
        {
            var userEntity = user.MapFromDomain();
            await _context.UserAccount.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            var userAccount = userEntity.MapToDomain();

            return userAccount;
        }

        public async Task<UserAccountDto> UpdateUserAsync(int id, UserAccountDto user)
        {
            var userAccount = await _context.UserAccount.FindAsync(id);

            if(userAccount != null)
            {
                userAccount.AccountId = user.AccountId;
                userAccount.FirstName = user.FirstName;
                userAccount.LastName = user.LastName;
                await _context.SaveChangesAsync();
            }
            return user;
        }

        public async Task<UserAccountDto> FindUserByIdAsync(int id)
        {
            var userAccount = await _context.UserAccount.FindAsync(id);

            return ProcessUserAccount(userAccount);
        }

        public async Task DeleteUserByIdAsync(int id)
        {
            var userAccount = await _context.UserAccount.FindAsync(id);
            if(userAccount != null)
            {
                _context.UserAccount.Remove(userAccount);
                await _context.SaveChangesAsync();
            }
        }

        private UserAccountDto ProcessUserAccount(UserAccount? userAccount)
        {
            if (userAccount == null)
                return null;

            return userAccount.MapToDomain();
        }
    }
}
