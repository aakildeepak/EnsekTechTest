namespace Ensek.TechTest.MeterRead.Services.Models
{
    public class MeterReadValidationResult
    {
        public bool IsValid { get; set; }
        public int AccountId { get; set; }
        public DateTime ReadingDateTime { get; set; }
        public string MeterReadValue { get; set; }
    }
}
