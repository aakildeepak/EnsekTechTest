using Ensek.TechTest.MeterRead.Data.Entities;
using Ensek.TechTest.MeterRead.Domain.Models;

namespace Ensek.TechTest.MeterRead.Repositories.Mappers
{
    public static class MeterReadingMapper
    {
        public static MeterReadingDto MapToDomain(this MeterReading meterReading)
        {
            if (meterReading == null)
                return null;

            return new MeterReadingDto
            {
                AccountId = meterReading.UserAccountId.ToString(),
                MeterReadingDateTime = meterReading.ReadingDateTime.ToString("yyyy-MM-ddTHH:mm:ss"),
                MeterReadingValue = meterReading.ReadingValue
            };
        }
    }
}
