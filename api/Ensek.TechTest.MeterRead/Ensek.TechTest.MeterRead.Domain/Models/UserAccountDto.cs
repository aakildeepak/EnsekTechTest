namespace Ensek.TechTest.MeterRead.Domain.Models
{
    public class UserAccountDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<MeterReadingDto> MeterReadings { get; set; } = new List<MeterReadingDto>();
    }
}
