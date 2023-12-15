using Ensek.TechTest.MeterRead.Domain.Models;

namespace Ensek.TechTest.MeterRead.Services
{
    public interface IFileReadService
    {
        IList<MeterReadingDto> ReadFile(MemoryStream memoryStream);
    }
}
