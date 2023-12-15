using Ensek.TechTest.MeterRead.Data.Entities;
using Ensek.TechTest.MeterRead.Domain.Models;

namespace Ensek.TechTest.MeterRead.Repositories.Mappers
{
    public static class UserAccountMapper
    {
        public static UserAccountDto MapToDomain(this UserAccount userAccount)
        {
            if (userAccount == null)
                return null;

            return new UserAccountDto
            {
                Id = userAccount.Id,
                AccountId = userAccount.AccountId,
                FirstName = userAccount.FirstName,
                LastName = userAccount.LastName,
                MeterReadings = userAccount.MeterReadings?.Select(m => m.MapToDomain()).ToList()
            };
        }

        public static UserAccount MapFromDomain(this UserAccountDto userAccount)
        {
            if (userAccount == null) 
                return null;

            return new UserAccount(userAccount.FirstName, userAccount.LastName)
            {
                AccountId = userAccount.AccountId
            };
        }
    }
}
