using Ensek.TechTest.MeterRead.Data.Entities;

namespace Ensek.TechTest.MeterRead.Data
{
    public static class MeterReadingData
    {
        public static IEnumerable<UserAccount> GetUserAccounts()
        {
            return new List<UserAccount>()
            {
                new UserAccount("Tommy", "Test") { Id = 1, AccountId = 2344 },
                new UserAccount("Barry", "Test") { Id = 2, AccountId = 2233 },
                new UserAccount("Sally", "Test") { Id = 3, AccountId = 8766 },
                new UserAccount("Jerry", "Test") { Id = 4, AccountId = 2345 },
                new UserAccount("Ollie", "Test") { Id = 5, AccountId = 2346 },
                new UserAccount("Tara", "Test") { Id = 6, AccountId = 2347},
                new UserAccount("Tammy", "Test") { Id = 7, AccountId = 2348 },
                new UserAccount("Simon", "Test") { Id = 8, AccountId = 2349 },
                new UserAccount("Colin", "Test") { Id = 9, AccountId = 2350 },
                new UserAccount("Gladys","Test") { Id = 10, AccountId = 2351 },
                new UserAccount("Greg", "Test") { Id = 11, AccountId = 2352 },
                new UserAccount("Tony", "Test") { Id = 12, AccountId = 2353 },
                new UserAccount("Arthur", "Test" ) { Id = 13, AccountId = 2355},
                new UserAccount("Craig", "Test" ) { Id = 14, AccountId = 2356},
                new UserAccount("Laura", "Test" ) { Id = 15, AccountId = 6776},
                new UserAccount("JOSH", "Test" ) { Id = 16, AccountId = 4534},
                new UserAccount("Freya", "Test" ) { Id = 17, AccountId = 1234},
                new UserAccount("Noddy", "Test" ) { Id = 18, AccountId = 1239},
                new UserAccount("Archie", "Test" ) { Id = 19, AccountId = 1240},
                new UserAccount("Lara", "Test" ) { Id = 20, AccountId = 1241},
                new UserAccount("Tim", "Test" ) { Id = 21, AccountId = 1242},
                new UserAccount("Graham", "Test" ) { Id = 22, AccountId = 1243},
                new UserAccount("Tony", "Test" ) { Id = 23, AccountId = 1244 },
                new UserAccount("Neville", "Test" ) { Id = 24, AccountId = 1245 },
                new UserAccount("Jo", "Test" ) { Id = 25, AccountId = 1246 },
                new UserAccount("Jim", "Test" ) { Id = 26, AccountId = 1247 },
                new UserAccount("Pam", "Test" ) { Id = 27, AccountId = 1248 }
            };
        }
    }
}
