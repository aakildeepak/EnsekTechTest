using Ensek.TechTest.MeterRead.Domain.Models;
using Ensek.TechTest.MeterRead.Services.Interfaces;
using Ensek.TechTest.MeterRead.Services.Models;
using System.Text.RegularExpressions;

namespace Ensek.TechTest.MeterRead.Services
{
    public class MeterReadValidatorService : IMeterReadValidatorService
    {
        public MeterReadValidationResult ValidateMeterReading(MeterReadingDto item)
        {
            var regex = new Regex(@"^[0-9]{5}$");

            bool validAccount = Int32.TryParse(item.AccountId, out int accountId);
            bool validDate = DateTime.TryParse(item.MeterReadingDateTime, out DateTime readingDateTime);
            bool validReadingValue = Int32.TryParse(item.MeterReadingValue, out int readingValue);

            Match match = regex.Match(item.MeterReadingValue);

            if(validDate && validAccount && validReadingValue && readingValue >= 0 && match.Success)
            {
                return new MeterReadValidationResult
                {
                    IsValid = true,
                    ReadingDateTime = readingDateTime,
                    MeterReadValue = item.MeterReadingValue,
                    AccountId = accountId
                };
            }

            return new MeterReadValidationResult { IsValid = false };
        }
    }
}
