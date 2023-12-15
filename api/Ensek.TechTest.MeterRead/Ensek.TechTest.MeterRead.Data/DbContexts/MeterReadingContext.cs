using Ensek.TechTest.MeterRead.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ensek.TechTest.MeterRead.Data.DbContexts
{
    public class MeterReadingContext :  DbContext
    {
        public DbSet<UserAccount> UserAccount { get; set; } = null!;
        public DbSet<MeterReading> MeterReading { get; set; } = null!;

        public MeterReadingContext(DbContextOptions<MeterReadingContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>().HasData(MeterReadingData.GetUserAccounts());
        }
    }
}
