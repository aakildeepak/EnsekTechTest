using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ensek.TechTest.MeterRead.Data.Entities
{
    public class MeterReading
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime ReadingDateTime { get; set; }

        public string ReadingValue { get; set; } = string.Empty;

        public int UserAccountId { get; set; }

        [ForeignKey("UserAccountId")]
        public UserAccount? UserAccount { get; set; }
    }
}
