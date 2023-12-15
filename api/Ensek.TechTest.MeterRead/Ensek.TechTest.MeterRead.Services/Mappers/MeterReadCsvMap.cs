using CsvHelper.Configuration;
using Ensek.TechTest.MeterRead.Domain.Models;

namespace Ensek.TechTest.MeterRead.Services.Mappers
{
    public sealed class MeterReadCsvMap : ClassMap<MeterReadingDto>
    {
        public MeterReadCsvMap()
        {
            Map(x => x.AccountId).Name("AccountId");
            Map(x => x.MeterReadingDateTime).Name("MeterReadingDateTime");
            Map(x => x.MeterReadingValue).Name("MeterReadValue");
        }
    }
}
