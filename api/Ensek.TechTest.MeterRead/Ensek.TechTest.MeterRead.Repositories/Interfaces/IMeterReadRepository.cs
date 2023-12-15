using Ensek.TechTest.MeterRead.Domain.Models;

namespace Ensek.TechTest.MeterRead.Repositories.Interfaces
{
    public interface IMeterReadRepository
    {
        Task<bool> MeterReadExistsAsync(int accountId, DateTime readingDateTime, string readingValue);
        Task<bool> CreateReadingAsync(int accountId, DateTime readingDateTime, string value);
    }
}
