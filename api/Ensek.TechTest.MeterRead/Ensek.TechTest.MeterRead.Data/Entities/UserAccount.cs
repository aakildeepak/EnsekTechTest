using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensek.TechTest.MeterRead.Data.Entities
{
    public class UserAccount
    {
        public UserAccount(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AccountId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        public ICollection<MeterReading> MeterReadings { get; set; } = new List<MeterReading>();
    }
}
