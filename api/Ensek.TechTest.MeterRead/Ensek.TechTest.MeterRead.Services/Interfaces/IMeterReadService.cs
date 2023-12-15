using Ensek.TechTest.MeterRead.Domain.Models;

namespace Ensek.TechTest.MeterRead.Services.Interfaces
{
    public interface IMeterReadService
    {
        Task<UploadResponse> UploadCsv(MemoryStream memoryStream);
        Task<bool> CreateReading(MeterReadingDto meterReading);
    }
}
