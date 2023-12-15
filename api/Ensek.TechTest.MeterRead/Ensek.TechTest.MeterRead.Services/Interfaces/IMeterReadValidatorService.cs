using Ensek.TechTest.MeterRead.Domain.Models;
using Ensek.TechTest.MeterRead.Services.Models;

namespace Ensek.TechTest.MeterRead.Services.Interfaces
{
    public interface IMeterReadValidatorService
    {
        MeterReadValidationResult ValidateMeterReading(MeterReadingDto item);
    }
}
