using CsvHelper;
using Ensek.TechTest.MeterRead.Domain.Models;
using Ensek.TechTest.MeterRead.Services.Mappers;
using System.Globalization;

namespace Ensek.TechTest.MeterRead.Services
{
    public class CsvFileReadService : IFileReadService
    {
        public IList<MeterReadingDto> ReadFile(MemoryStream memoryStream)
        {
            using var reader = new StreamReader(memoryStream);
            using var csvReader = new CsvReader(reader, CultureInfo.GetCultureInfo("en-GB"));
            csvReader.Configuration.RegisterClassMap<MeterReadCsvMap>();
            var records = csvReader.GetRecords<MeterReadingDto>().ToList();

            return records;
        }
    }
}
