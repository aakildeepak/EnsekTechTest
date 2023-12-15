using Ensek.TechTest.MeterRead.Data.DbContexts;
using Ensek.TechTest.MeterRead.Data.Entities;
using Ensek.TechTest.MeterRead.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ensek.TechTest.MeterRead.Repositories
{
    public class MeterReadRepository : IMeterReadRepository
    {
        private readonly MeterReadingContext _context;

        public MeterReadRepository(MeterReadingContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateReadingAsync(int accountId, DateTime readingDateTime, string value)
        {
            var meterReading = new MeterReading
            {
                ReadingDateTime = readingDateTime,
                ReadingValue = value,
                UserAccountId = accountId
            };

            await _context.MeterReading.AddAsync(meterReading);

            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<bool> MeterReadExistsAsync(
            int accountId, 
            DateTime readingDateTime, 
            string readingValue
            )
        {
            var meterReading = await _context.MeterReading.AsNoTracking()
                                    .Where(x => x.UserAccountId == accountId
                                        && x.ReadingDateTime == readingDateTime
                                        && x.ReadingValue == readingValue)
                                    .FirstOrDefaultAsync();

            return meterReading != null;
        }
    }
}
